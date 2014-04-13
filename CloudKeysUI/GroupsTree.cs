using System;
using System.Windows.Forms;

namespace CloudKeysUI
{
    public partial class GroupsTree : UserControl
    {
        public GroupsTree()
        {
            InitializeComponent();
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
