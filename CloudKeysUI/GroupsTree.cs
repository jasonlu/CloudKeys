using System;
using System.Windows.Forms;

namespace CloudKeysUI
{
    public partial class GroupsTree : UserControl
    {
        private CloudKeysController.KeyChainMgr _mgr;
        public GroupsTree()
        {
            InitializeComponent();
            MainForm f = (MainForm)this.ParentForm;
            _mgr = f.KeyChainMgr;

        }

        private void _toolbarNewGroup_Click(object sender, EventArgs e)
        {
            GroupDialog gd = new GroupDialog();
            DialogResult dialogResult = gd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {

            }
        }
    }
}
