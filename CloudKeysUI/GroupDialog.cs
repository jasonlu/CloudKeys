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
    public partial class GroupDialog : Form
    {
        Group _group;
        KeyChainMgr _mgr = new KeyChainMgr();

        public Group Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public GroupDialog()
        {
            InitializeComponent();
            Application.Idle += OnIdle;
        }

        void OnIdle(object sender, EventArgs e)
        {
            if (_textboxGroupName.Text == "")
                _btnOk.Enabled = false;
            else
                _btnOk.Enabled = true;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _group.Title = _textboxGroupName.Text;
            this.Tag = _group;
            DialogResult = DialogResult.OK;
        }

        private void GroupDialog_Load(object sender, EventArgs e)
        {
            if (_group == null)
            {
                _group = new Group();
            }
            _textboxGroupName.Text = _group.Title;
        }

        private void _btnTest_Click(object sender, EventArgs e)
        {
            _textboxGroupName.Text = _mgr.RandomString(10);
        }
    }
}
