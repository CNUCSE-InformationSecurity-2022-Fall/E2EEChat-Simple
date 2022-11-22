namespace SecretChat
{
    partial class LoginForm
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
            this.nicknameInput = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.serverUrlInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nicknameInput
            // 
            this.nicknameInput.Location = new System.Drawing.Point(4, 11);
            this.nicknameInput.Margin = new System.Windows.Forms.Padding(2);
            this.nicknameInput.Name = "nicknameInput";
            this.nicknameInput.Size = new System.Drawing.Size(347, 20);
            this.nicknameInput.TabIndex = 0;
            this.nicknameInput.Text = "닉네임";
            this.nicknameInput.Click += new System.EventHandler(this.nicknameInput_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(355, 11);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(66, 44);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // serverUrlInput
            // 
            this.serverUrlInput.Location = new System.Drawing.Point(4, 35);
            this.serverUrlInput.Margin = new System.Windows.Forms.Padding(2);
            this.serverUrlInput.Name = "serverUrlInput";
            this.serverUrlInput.Size = new System.Drawing.Size(347, 20);
            this.serverUrlInput.TabIndex = 0;
            this.serverUrlInput.Text = "서버 주소";
            this.serverUrlInput.Click += new System.EventHandler(this.serverUrlInput_Click);
            this.serverUrlInput.TextChanged += new System.EventHandler(this.serverUrlInput_TextChanged);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(432, 67);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.serverUrlInput);
            this.Controls.Add(this.nicknameInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "보안채팅: 닉네임을 입력하세요...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nicknameInput;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox serverUrlInput;
    }
}

