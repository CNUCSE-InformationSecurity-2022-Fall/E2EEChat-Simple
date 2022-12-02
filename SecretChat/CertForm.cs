using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretChat
{
    public partial class CertForm : Form
    {
        string Sha256Fingerprint(string keyStr) => Sha256Fingerprint(Convert.FromBase64String(keyStr));

        string Sha256Fingerprint(byte[] keyBytes) => BitConverter.ToString(
            SHA256.Create().ComputeHash(keyBytes).Take(6).ToArray()
        );

        string ToPem(string base64) => Encoding.UTF8.GetString(Convert.FromBase64String(base64));

        public CertForm(Certificate cert)
        {
            InitializeComponent();

            txtNickname.Text = cert.Name;

            userPubKeyFingerprint.Text = Sha256Fingerprint(cert.PubKey);
            txtUserPubKey.Text = ToPem(cert.PubKey);

            serverPubKeyFingerprint.Text = Sha256Fingerprint(cert.ServerPubKey);
            txtServerPubKey.Text = ToPem(cert.ServerPubKey);

            txtPubKeyHash.Text = cert.Hash;
            txtServerSignature.Text = cert.Signature;

            txtCertValidity.Text = cert.IsValid ? "인증서가 유효합니다. (서버 서명 유효)" : "인증서가 유효하지 않습니다.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
