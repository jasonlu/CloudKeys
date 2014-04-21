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

namespace CloudKeysUI
{
    public partial class KeyList : UserControl
    {
        private KeyChainMgr _mgr;

        public KeyChainMgr KeyChainMgr
        {
            get { return _mgr; }
            set { _mgr = value; }
        }


        public KeyList()
        {
            InitializeComponent();
        }

        private void KeyList_Load(object sender, EventArgs e)
        {

            //_mgr = f.KeyChainMgr;
        }
    }
}
