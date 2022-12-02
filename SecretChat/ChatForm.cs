using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretChat
{
    public partial class ChatForm : Form
    {
        DebuggingForm _debuggingForm;

        HubConnection _connection;
        string _nickname;

        byte[] _secretKey;
        byte[] _privateKey;
        byte[] _publicKey;

        bool _sessionAvailable = false;

        string _secretKeyBase64 => Convert.ToBase64String(_secretKey);
        string _privateKeyBase64 => Convert.ToBase64String(_privateKey);
        string _publicKeyBase64 => Convert.ToBase64String(_publicKey);

        string _publicKeySignature => Sha256Fingerprint(_publicKey);

        string Sha256Fingerprint(byte[] keyBytes) => BitConverter.ToString(
            SHA256.Create().ComputeHash(keyBytes).Take(6).ToArray()
        );

        bool _securedMode => _secretKey != null && _privateKey != null && _publicKey != null;

        Dictionary<string, string> _sharedKeys;
        Dictionary<string, string> _sharedPublicKeys;

        public ChatForm()
        {
            InitializeComponent();

            _debuggingForm = new DebuggingForm();
            chkDebug.Checked = true;

            _sharedKeys = new Dictionary<string, string>();
            _sharedPublicKeys = new Dictionary<string, string>();

            GenerateKey();
        }

        public ChatForm(string url) : this()
        {
            _connection = new HubConnectionBuilder()
                        .WithUrl(url)
                        .Build();
        }

        public new void Dispose()
        {
            if (_debuggingForm != null)
            {
                _debuggingForm.Dispose();
            }

            base.Dispose();
        }

        public string ExecuteScript(string scriptName, params string[] args)
        {
            return Program.ExecuteScript(_debuggingForm, scriptName, args);
        }

        public bool ReportAndRetry(string message, Action action, Action ignored = null)
        {
            var result = MessageBox.Show(message, "오류", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            if (result == DialogResult.Retry)
            {
                action();
                return true;
            }
            else if (result == DialogResult.Abort)
            {
                Application.Exit();
            }
            else
            {
                ignored?.Invoke();
            }

            return false;
        }

        public void GenerateKey()
        {
            var genKey = ExecuteScript("generate-keys.py");

            if (string.IsNullOrEmpty(genKey))
            {
               ReportAndRetry(
                    "키 생성 스크립트 실행 실패!!! 재시도 할까요?", 
                    GenerateKey,
                    () => pubKeySignature.Text = "비보안모드로 작동중!!!");

                return;
            }

            var genKeyList = genKey.Split('\n');

            if (genKeyList.Length < 3)
            {
                ReportAndRetry(
                    "키가 부족하게 생성되었습니다!!!\n" + 
                    "키는 총 3가지(비밀키, 공개키, 개인키)가 순서대로 생성되어야 합니다.\n" + 
                    "재시도 할까요?", 
                    GenerateKey,
                    () => pubKeySignature.Text = "비보안모드로 작동중!!!");

                return;
            }

            try
            {
                _secretKey = Convert.FromBase64String(genKeyList[0]);
                _publicKey = Convert.FromBase64String(genKeyList[1]);
                _privateKey = Convert.FromBase64String(genKeyList[2]);

                pubKeySignature.Text = "공개키 핑거프린트: " + _publicKeySignature;
            }
            catch (Exception)
            {
                ReportAndRetry(
                    "키가 잘못 생성된 것 같습니다. BASE64가 맞는지 확인해보세요!!!\n" +
                    "재시도 할까요?", 
                    GenerateKey,
                    () => pubKeySignature.Text = "비보안모드로 작동중!!!");
            }
        }

        public bool SetNickname(in string nickname)
        {
            var safeNickname = nickname.Trim();

            if (safeNickname.Length == 0)
            {
                MessageBox.Show("닉네임을 제대로 입력해주세요!!!");
                return false;
            }

            if (InvokeRequired)
                Invoke(new Action(() => lblNickname.Text = safeNickname));
            else
                lblNickname.Text = safeNickname;

            _nickname = safeNickname;

            return TryConnect(_nickname);
        }

        private void ConfigureConnectionCallbacks()
        {
            _connection.On<bool>("LoginResult", LoginCallback);
            _connection.On<string>("BroadcastNewUser", BroadcastNewUserCallback);
            _connection.On<string>("BroadcastUserOut", BroadcastUserOutCallback);
            _connection.On<List<string>>("CurrentUserList", CurrentUserListCallback);
            _connection.On<string, string>("MessageBroadcast", MessageBroadcastCallback);
            _connection.On<string, string>("CommonKeyExchange", CommonKeyExchangeCallback);
            _connection.On<string, string>("CommonKeyExchangeResponse", CommonKeyExchangeResponseCallback);
            _connection.On<string>("RequestCertificateResponse", RequestUserCertificateCallback);
        }

        private void LoginCallback(bool loginResult)
        {
            try
            {
                if (!loginResult)
                {
                    MessageBox.Show("로그인 실패!");

                    _debuggingForm.Close();
                    this.Close();

                    return;
                }

                _sessionAvailable = true;
                Invoke(new Action(() => messageInput?.Focus()));
            }
            catch
            {
                return;
            }
        }

        private void LogMessage(string from, string message, bool secured = false, string signature = null)
        {
            if (InvokeRequired && !IsDisposed)
                Invoke(new Action(() => {
                    var listViewItem = new ListViewItem(from);
                    listViewItem.Tag = signature;
                    listViewItem.SubItems.Add(message);
                    listViewItem.SubItems.Add(DateTime.Now.ToString());

                    if (secured)
                    {
                        listViewItem.ForeColor = Color.White;
                        listViewItem.BackColor = Color.Green;
                    }

                    chatList.Items.Add(listViewItem);
                }));
        }

        private void BroadcastNewUserCallback(string username)
        {
            LogMessage("SYSTEM", username + "님이 접속하셨습니다.");
            _connection?.SendAsync("RequestUserList");
        }

        private void BroadcastUserOutCallback(string username)
        {
            LogMessage("SYSTEM", username + "님이 나가셨습니다.");
            _connection?.SendAsync("RequestUserList");
        }

        private void CurrentUserListCallback(List<string> userList)
        {
            if (InvokeRequired && !IsDisposed)
                Invoke(new Action(() =>
                {
                    currentUserList.Items.Clear();
                    userList.Select(u => {
                        var userInfo = u.Split(':');
                        var userItem = new ListViewItem(userInfo[0])
                        {
                            ForeColor = userInfo[0] == _nickname ? 
                                        Color.Red :
                                        LookupSharedKeys(userInfo[0]) == null ? Color.Black : Color.Blue
                        };

                        var pubKey = Convert.FromBase64String(userInfo[1]);
                        userItem.SubItems.Add(Sha256Fingerprint(pubKey));

                        if (!_sharedPublicKeys.ContainsKey(userInfo[0]))
                            _sharedPublicKeys.Add(userInfo[0], userInfo[1]);

                        return userItem;
                    }).ToList()
                    .ForEach(i => currentUserList.Items.Add(i));
                    
                }));
        }

        private string LookupSharedKeys(string from)
        {
            if (_sharedKeys.ContainsKey(from))
            {
                return _sharedKeys[from];
            }

            return null;
        }

        private void MessageBroadcastCallback(string from, string message)
        {
            var messageToPrint = message;
            var secured = message.StartsWith("secured-aes256:");
            var signature = "";

            if (secured)
            {
                var key = from == _nickname ? _secretKeyBase64 : LookupSharedKeys(from);

                if (key != null)
                {
                    var payload = message.Split(':')[1].Split('!');

                    if (payload.Length >= 2)
                    {
                        messageToPrint = ExecuteScript("decrypt-message.py", key, payload[0], payload[1]);

                        if (payload.Length == 3)
                        {
                            signature = payload[2];
                        }
                        else
                        {
                            signature = null;
                        }
                    }
                    else
                    {
                        messageToPrint = "복호화 실패: 암호 메세지에 오류가 있음!";
                        secured = false;
                    }
                }
                else
                {
                    messageToPrint = "복호화 실패: 키 교환이 되지 않은 사용자입니다!";
                    secured = false;
                }
            }

            LogMessage(from, messageToPrint, secured, signature);
        }

        private void CommonKeyExchangeCallback(string user, string pubKey)
        {
            var key = ExecuteScript("encrypt-secret.py", _secretKeyBase64, pubKey);

            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            _connection?.SendAsync("CommonKeyExchangeResponse", _nickname, user, key).Wait();
            
            if (!_sharedKeys.ContainsKey(user))
                _connection?.SendAsync("CommonKeyExchange", _nickname, user, _publicKeyBase64).Wait();
        }

        private void CommonKeyExchangeResponseCallback(string user, string response)
        {
            var key = ExecuteScript("decrypt-secret.py", response, _privateKeyBase64);

            if (!string.IsNullOrEmpty(key))
            {
                _sharedKeys.Add(user, key);
                _connection?.SendAsync("RequestUserList");
            }
        }

        private bool TryConnect(in string nickname)
        {
            ConfigureConnectionCallbacks();

            try
            {
                _connection.StartAsync().Wait();
                _connection.SendAsync("Login", nickname, _publicKeyBase64);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("릴레이 서버 접속에 실패하였습니다!!!\n" + ex.InnerException?.Message);
                return false;
            }
        }

        private void CloseConnection()
        {
            _connection?.SendAsync("Logout", _nickname);
            _connection = null;
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_connection is null || !_sessionAvailable)
                return;

            if (MessageBox.Show("정말로 종료하시겠습니까?", "보안채팅", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                CloseConnection();
                Application.Exit();
                
                return;
            }

            e.Cancel = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var message = messageInput.Text;

            if (!string.IsNullOrEmpty(message))
            {
                if (_securedMode && chkSecuredMessage.Checked)
                {
                    var complMessage = ExecuteScript("encrypt-message.py", _secretKeyBase64, message);
                    complMessage = "secured-aes256:" + complMessage;

                    var signature = ExecuteScript("sign-message.py", message, _privateKeyBase64);
                    complMessage += "!" + signature;

                    message = complMessage;
                }

                _connection.SendAsync("SendMessage", message).Wait();
            }

            messageInput.Clear();
            messageInput.Focus();
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDebug.Checked)
                _debuggingForm.Show();
            else
                _debuggingForm.Hide();
        }

        private void userListMenu_Opening(object sender, CancelEventArgs e)
        {
            if (currentUserList.SelectedItems.Count > 0)
            {
                var userItem = currentUserList.SelectedItems[0];

                if (userItem.Text == _nickname)
                    e.Cancel = true;

                contextMenuRequestKeyExchange.Enabled = LookupSharedKeys(userItem.Text) == null;
            }
            else 
            {
                contextMenuRequestKeyExchange.Enabled = false;
            }
        }

        private void contextMenuRequestKeyExchange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("이 사용자에게 키 교환을 요청하시겠습니까?", "키 교환 요청", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _connection.SendAsync("CommonKeyExchange", _nickname, currentUserList.SelectedItems[0].Text, _publicKeyBase64);
            }
        }

        private void chatList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (chatList.SelectedItems.Count > 0)
            {
                var item = chatList.SelectedItems[0];

                var userName = item.Text;

                if (userName == _nickname || userName == "SYSTEM")
                    return;

                var message = item.SubItems[1].Text;
                var signature = item.Tag as string;
                var pubKey = _sharedPublicKeys[userName];

                if (signature == null)
                {
                    MessageBox.Show("이 메세지에는 서명이 포함되어 있지 않습니다.", "무결성 검증", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var result = ExecuteScript("verify-message.py", message, pubKey, signature);

                if (result.Trim() == "ok")
                {
                    MessageBox.Show("이 메세지는 올바르게 서명되었습니다.", "무결성 검증", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("이 메세지는 위조되었을 가능성이 있습니다.", "무결성 검증", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void RequestUserCertificate(object sender, EventArgs e)
        {
            _connection.SendAsync("RequestCertificate", currentUserList.SelectedItems[0].Text);
        }

        private void RequestUserCertificateCallback(string certificate)
        {
            try
            {
                if (certificate == null)
                    return;

                var result = ExecuteScript("verify-certificate.py", certificate);

                var jsonBytes = Convert.FromBase64String(result);
                var json = Encoding.UTF8.GetString(jsonBytes);
                var cert = JsonConvert.DeserializeObject<Certificate>(json);

                if (cert == null)
                {
                    throw new Exception("인증서 형식이 잘못되었습니다!!!");   
                }

                var form = new CertForm(cert);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"인증서 처리 실패!!!\n{ex.Message}", "인증서 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
