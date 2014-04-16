using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudKeysUI
{
    public partial class KeyList : UserControl
    {

        private CloudKeysController.KeyChainMgr _mgr;

        public KeyList()
        {
            InitializeComponent();
            MainForm f = (MainForm)this.ParentForm;
            _mgr = f.KeyChainMgr;
        }
    }
}
