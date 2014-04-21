using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudKeysController;
using CloudKeysModel;

namespace CloudKeysUI
{
    public partial class KeyList : UserControl
    {
        private MainForm _mainForm;

        public MainForm MainForm
        {
            get { return _mainForm; }
            set { _mainForm = value; }
        }
        

        private KeyChainMgr _mgr;

        public KeyChainMgr KeyChainMgr
        {
            get { return _mgr; }
            set { _mgr = value; }
        }

        public KeyList()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
            _mgr = new KeyChainMgr();
        }

        public void LoadKeys()
        {
            _listview.Items.Clear();
            List<Key> keys = _mgr.KeyChain.CurrentGroup.Keys;
            foreach (Key k in keys)
            {
                ListViewItem item = new ListViewItem(new string[] { k.Title, k.URL, k.Username, k.Password });
                _listview.Items.Add(item);
            }
        }

        

        #region Event Handlers
        void Application_Idle(object sender, EventArgs e)
        {
            if (_mgr.KeyChain.CurrentGroup == null)
            {
                _toolbarNewKey.Enabled = false;
            }
            else
            {
                _toolbarNewKey.Enabled = true;
            }
        }

        #region Toolbar Event Handlers
        private void _toolbarNewKey_Click(object sender, EventArgs e)
        {
            KeyDialog kd = new KeyDialog();
            if (kd.ShowDialog() == DialogResult.OK)
            {
                Key k = kd.Key;
                _mgr.KeyChain.CurrentGroup.Keys.Add(k);
                ListViewItem item = new ListViewItem(new string[] {k.Title, k.URL, k.Username, k.Password} );
                _listview.Items.Add(item);
            }
        }

        private void _toolbarEditKey_Click(object sender, EventArgs e)
        {

        }

        private void _toobarDeleteKeys_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion

    }
}
