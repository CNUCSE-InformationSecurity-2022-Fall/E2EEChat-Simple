using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretChat
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var form = new ChatForm(serverUrlInput.Text);

            if (form.SetNickname(nicknameInput.Text))
            {
                form.Show();
                Hide();
            }
        }

        private void nicknameInput_Click(object sender, EventArgs e)
        {
            nicknameInput.Clear();
        }

        private void serverUrlInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void serverUrlInput_Click(object sender, EventArgs e)
        {
            serverUrlInput.Clear();
        }
    }
}
