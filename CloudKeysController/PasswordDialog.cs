using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudKeysController
{
    public partial class PasswordDialog : Form
    {

        private string _realPassword;

        public string RealPassword
        {
            get { return _realPassword; }
            set { _realPassword = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _filename = "";

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }


        public PasswordDialog()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (_txtPassword.Text == "")
            {
                _btnOK.Enabled = false;
            }
            else
            {
                _btnOK.Enabled = true;
            }
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            _password = _txtPassword.Text;
            if (_password != _realPassword)
            {
                MessageBox.Show("Wrong Password!", "Who are you?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _txtPassword.SelectAll();
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void PasswordDialog_Shown(object sender, EventArgs e)
        {
            lblFilename.Text = _filename.Substring(_filename.LastIndexOf("\\") + 1);
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        
    }
}
