namespace SecretChat
{
    partial class CertForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.txtUserPubKey = new System.Windows.Forms.TextBox();
            this.txtServerPubKey = new System.Windows.Forms.TextBox();
            this.txtServerSignature = new System.Windows.Forms.TextBox();
            this.txtCertValidity = new System.Windows.Forms.TextBox();
            this.userPubKeyFingerprint = new System.Windows.Forms.Label();
            this.serverPubKeyFingerprint = new System.Windows.Forms.Label();
            this.txtPubKeyHash = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "사용자 닉네임";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "공개키";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "서버 공개키";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "서버 서명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "인증서 유효성";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(387, 364);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "확인";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(94, 16);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.ReadOnly = true;
            this.txtNickname.Size = new System.Drawing.Size(368, 20);
            this.txtNickname.TabIndex = 2;
            // 
            // txtUserPubKey
            // 
            this.txtUserPubKey.Location = new System.Drawing.Point(94, 73);
            this.txtUserPubKey.Multiline = true;
            this.txtUserPubKey.Name = "txtUserPubKey";
            this.txtUserPubKey.ReadOnly = true;
            this.txtUserPubKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserPubKey.Size = new System.Drawing.Size(368, 51);
            this.txtUserPubKey.TabIndex = 2;
            // 
            // txtServerPubKey
            // 
            this.txtServerPubKey.Location = new System.Drawing.Point(94, 157);
            this.txtServerPubKey.Multiline = true;
            this.txtServerPubKey.Name = "txtServerPubKey";
            this.txtServerPubKey.ReadOnly = true;
            this.txtServerPubKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServerPubKey.Size = new System.Drawing.Size(368, 51);
            this.txtServerPubKey.TabIndex = 2;
            // 
            // txtServerSignature
            // 
            this.txtServerSignature.Location = new System.Drawing.Point(94, 253);
            this.txtServerSignature.Multiline = true;
            this.txtServerSignature.Name = "txtServerSignature";
            this.txtServerSignature.ReadOnly = true;
            this.txtServerSignature.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServerSignature.Size = new System.Drawing.Size(368, 76);
            this.txtServerSignature.TabIndex = 2;
            // 
            // txtCertValidity
            // 
            this.txtCertValidity.Location = new System.Drawing.Point(94, 338);
            this.txtCertValidity.Name = "txtCertValidity";
            this.txtCertValidity.ReadOnly = true;
            this.txtCertValidity.Size = new System.Drawing.Size(368, 20);
            this.txtCertValidity.TabIndex = 2;
            // 
            // userPubKeyFingerprint
            // 
            this.userPubKeyFingerprint.AutoSize = true;
            this.userPubKeyFingerprint.Location = new System.Drawing.Point(91, 49);
            this.userPubKeyFingerprint.Name = "userPubKeyFingerprint";
            this.userPubKeyFingerprint.Size = new System.Drawing.Size(113, 13);
            this.userPubKeyFingerprint.TabIndex = 3;
            this.userPubKeyFingerprint.Text = "userPubKeyFingerprint";
            // 
            // serverPubKeyFingerprint
            // 
            this.serverPubKeyFingerprint.AutoSize = true;
            this.serverPubKeyFingerprint.Location = new System.Drawing.Point(91, 137);
            this.serverPubKeyFingerprint.Name = "serverPubKeyFingerprint";
            this.serverPubKeyFingerprint.Size = new System.Drawing.Size(122, 13);
            this.serverPubKeyFingerprint.TabIndex = 3;
            this.serverPubKeyFingerprint.Text = "serverPubKeyFingerprint";
            // 
            // txtPubKeyHash
            // 
            this.txtPubKeyHash.Location = new System.Drawing.Point(94, 221);
            this.txtPubKeyHash.Name = "txtPubKeyHash";
            this.txtPubKeyHash.ReadOnly = true;
            this.txtPubKeyHash.Size = new System.Drawing.Size(368, 20);
            this.txtPubKeyHash.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "공개키 해시값";
            // 
            // CertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 414);
            this.Controls.Add(this.txtPubKeyHash);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.serverPubKeyFingerprint);
            this.Controls.Add(this.userPubKeyFingerprint);
            this.Controls.Add(this.txtServerSignature);
            this.Controls.Add(this.txtServerPubKey);
            this.Controls.Add(this.txtUserPubKey);
            this.Controls.Add(this.txtCertValidity);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CertForm";
            this.Text = "인증서 정보";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.TextBox txtUserPubKey;
        private System.Windows.Forms.TextBox txtServerPubKey;
        private System.Windows.Forms.TextBox txtServerSignature;
        private System.Windows.Forms.TextBox txtCertValidity;
        private System.Windows.Forms.Label userPubKeyFingerprint;
        private System.Windows.Forms.Label serverPubKeyFingerprint;
        private System.Windows.Forms.TextBox txtPubKeyHash;
        private System.Windows.Forms.Label label6;
    }
}