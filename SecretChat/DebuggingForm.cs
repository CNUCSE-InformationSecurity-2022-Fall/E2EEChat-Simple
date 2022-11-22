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
    public partial class DebuggingForm : Form
    {
        public DebuggingForm()
        {
            InitializeComponent();
        }

        public void AppendLog(string logFmt, params object[] args)
        {
            var msg = string.Format(logFmt, args);
            Invoke(new Action(() => consoleBox.AppendText(msg)));
        }
    }
}
