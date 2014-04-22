using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudKeysModel;
using CloudKeysController;

namespace CloudKeysUI
{
    public partial class KeyDialog : Form
    {
        private Key _key;

        public Key Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public KeyDialog()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if(
                _tboxName.Text == "" ||
                _tboxPassword.Text == "" ||
                _tboxURL.Text == "" ||
                _tboxUsername.Text == ""
            )
            {
                _btnOK.Enabled = false;
            }
            else
            {
                _btnOK.Enabled = true;
            }
            
        }

        private void KeyDialog_Load(object sender, EventArgs e)
        {
            if (_key == null)
            {
                _key = new Key();
            }
            else
            {
                Key cloneKey = _key.Clone();
                _key = cloneKey;
                _tboxName.Text = _key.Title;
                _tboxNotes.Text = _key.Notes;
                _tboxPassword.Text = _key.Password;
                _tboxURL.Text = _key.URL;
                _tboxUsername.Text = _key.Username;

            }
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            _key.Username = _tboxUsername.Text;
            _key.URL = _tboxURL.Text;
            _key.Title = _tboxName.Text;
            _key.Password = _tboxPassword.Text;
            _key.Notes = _tboxNotes.Text;
            DialogResult = DialogResult.OK;

        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void _btnTest_Click(object sender, EventArgs e)
        {
            KeyChainMgr mgr = new KeyChainMgr();

            _tboxName.Text = mgr.RandomString(10);
            _tboxNotes.Text = mgr.RandomString(1000);
            _tboxPassword.Text = mgr.RandomString(10);
            _tboxURL.Text = mgr.RandomString(10);
            _tboxUsername.Text = mgr.RandomString(10);
        }
    }
}
