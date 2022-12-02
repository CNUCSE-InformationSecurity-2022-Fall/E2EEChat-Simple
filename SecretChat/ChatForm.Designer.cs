namespace SecretChat
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.chatList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.messageInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.currentUserList = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuRequestKeyExchange = new System.Windows.Forms.ToolStripMenuItem();
            this.인증서확인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pubKeySignature = new System.Windows.Forms.Label();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.chkSecuredMessage = new System.Windows.Forms.CheckBox();
            this.userListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "로그인 됨: ";
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.ForeColor = System.Drawing.Color.Blue;
            this.lblNickname.Location = new System.Drawing.Point(78, 9);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(40, 13);
            this.lblNickname.TabIndex = 0;
            this.lblNickname.Text = "닉네임";
            // 
            // chatList
            // 
            this.chatList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.chatList.FullRowSelect = true;
            this.chatList.HideSelection = false;
            this.chatList.Location = new System.Drawing.Point(13, 73);
            this.chatList.Name = "chatList";
            this.chatList.Size = new System.Drawing.Size(570, 365);
            this.chatList.TabIndex = 1;
            this.chatList.UseCompatibleStateImageBehavior = false;
            this.chatList.View = System.Windows.Forms.View.Details;
            this.chatList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chatList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "발신자";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "메세지";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "시간";
            this.columnHeader3.Width = 160;
            // 
            // messageInput
            // 
            this.messageInput.Location = new System.Drawing.Point(13, 444);
            this.messageInput.Name = "messageInput";
            this.messageInput.Size = new System.Drawing.Size(455, 20);
            this.messageInput.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(528, 444);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(55, 21);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // currentUserList
            // 
            this.currentUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.currentUserList.ContextMenuStrip = this.userListMenu;
            this.currentUserList.FullRowSelect = true;
            this.currentUserList.HideSelection = false;
            this.currentUserList.Location = new System.Drawing.Point(589, 73);
            this.currentUserList.Name = "currentUserList";
            this.currentUserList.Size = new System.Drawing.Size(208, 391);
            this.currentUserList.TabIndex = 4;
            this.currentUserList.UseCompatibleStateImageBehavior = false;
            this.currentUserList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "닉네임";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "공개키";
            this.columnHeader5.Width = 80;
            // 
            // userListMenu
            // 
            this.userListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuRequestKeyExchange,
            this.인증서확인ToolStripMenuItem});
            this.userListMenu.Name = "userListMenu";
            this.userListMenu.Size = new System.Drawing.Size(181, 70);
            this.userListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.userListMenu_Opening);
            // 
            // contextMenuRequestKeyExchange
            // 
            this.contextMenuRequestKeyExchange.Name = "contextMenuRequestKeyExchange";
            this.contextMenuRequestKeyExchange.Size = new System.Drawing.Size(180, 22);
            this.contextMenuRequestKeyExchange.Text = "키 교환 요청";
            this.contextMenuRequestKeyExchange.Click += new System.EventHandler(this.contextMenuRequestKeyExchange_Click);
            // 
            // 인증서확인ToolStripMenuItem
            // 
            this.인증서확인ToolStripMenuItem.Name = "인증서확인ToolStripMenuItem";
            this.인증서확인ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.인증서확인ToolStripMenuItem.Text = "인증서 확인";
            this.인증서확인ToolStripMenuItem.Click += new System.EventHandler(this.RequestUserCertificate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "채팅기록";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "현재접속자";
            // 
            // pubKeySignature
            // 
            this.pubKeySignature.AutoSize = true;
            this.pubKeySignature.ForeColor = System.Drawing.Color.Red;
            this.pubKeySignature.Location = new System.Drawing.Point(78, 32);
            this.pubKeySignature.Name = "pubKeySignature";
            this.pubKeySignature.Size = new System.Drawing.Size(138, 13);
            this.pubKeySignature.TabIndex = 6;
            this.pubKeySignature.Text = "PUBLIC_KEY SIGNATURE";
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(713, 5);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(84, 17);
            this.chkDebug.TabIndex = 7;
            this.chkDebug.Text = "디버깅 콘솔";
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.chkDebug_CheckedChanged);
            // 
            // chkSecuredMessage
            // 
            this.chkSecuredMessage.AutoSize = true;
            this.chkSecuredMessage.Checked = true;
            this.chkSecuredMessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSecuredMessage.Location = new System.Drawing.Point(474, 446);
            this.chkSecuredMessage.Name = "chkSecuredMessage";
            this.chkSecuredMessage.Size = new System.Drawing.Size(48, 17);
            this.chkSecuredMessage.TabIndex = 8;
            this.chkSecuredMessage.Text = "보안";
            this.chkSecuredMessage.UseVisualStyleBackColor = true;
            // 
            // ChatForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(809, 476);
            this.Controls.Add(this.chkSecuredMessage);
            this.Controls.Add(this.chkDebug);
            this.Controls.Add(this.pubKeySignature);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentUserList);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.messageInput);
            this.Controls.Add(this.chatList);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChatForm";
            this.Text = "보안채팅방";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.userListMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.ListView chatList;
        private System.Windows.Forms.TextBox messageInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView currentUserList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label pubKeySignature;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.ContextMenuStrip userListMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRequestKeyExchange;
        private System.Windows.Forms.CheckBox chkSecuredMessage;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripMenuItem 인증서확인ToolStripMenuItem;
    }
}