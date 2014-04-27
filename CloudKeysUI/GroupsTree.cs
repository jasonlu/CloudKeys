using System;
using System.Windows.Forms;
using CloudKeysModel;
using CloudKeysController;
using System.Collections.Generic;

namespace CloudKeysUI
{
    public partial class GroupsTree : UserControl
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

        public GroupsTree()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
            _mainForm = (MainForm)this.ParentForm;
            _mgr = new KeyChainMgr();
        }

        public void OpenGroupDailog(Group g = null)
        {
            GroupDialog gd = new GroupDialog();
            gd.Group = g;
            DialogResult dialogResult = gd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Group newGroup = gd.Group;
                if (g == null) //Means "new" mode.
                {
                    _mgr.AddGroup(newGroup);
                    TreeNode newNode = new TreeNode();
                    newNode.Tag = newGroup;
                    newNode.Text = newGroup.Title;
                    newNode.ForeColor = newGroup.Color;
                    _treeview.Nodes.Add(newNode);
                    _treeview.SelectedNode = newNode;
                }
                else
                {
                    _treeview.SelectedNode.Text = newGroup.Title;
                    _treeview.SelectedNode.ForeColor = newGroup.Color;
                    _mgr.EditGroup(newGroup);
                }
                _mgr.KeyChain.Saved = false;
            }
        }

        public void LoadGroups()
        {
            List<Group> groups = _mgr.GetGroups();
            _treeview.Nodes.Clear();
            foreach (Group g in groups)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Tag = g;
                treeNode.Text = g.Title;
                treeNode.ForeColor = g.Color;
                _treeview.Nodes.Add(treeNode);
            }

        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (_treeview.SelectedNode == null)
            {
                _toolbarEditGroup.Enabled =
                _toolbarDeleteGroup.Enabled =
                deleteGroupToolStripMenuItem.Enabled =
                copyGroupToolStripMenuItem.Enabled =
                duplicateGroupToolStripMenuItem.Enabled = false;

            }
            else
            {
                _toolbarEditGroup.Enabled =
                _toolbarDeleteGroup.Enabled =
                deleteGroupToolStripMenuItem.Enabled =
                copyGroupToolStripMenuItem.Enabled =
                duplicateGroupToolStripMenuItem.Enabled = true;
            }
            _treeview.Font = PreferencesMgr.Preference.Font;
            /*
            if (Clipboard.ContainsData("KeyChainGroup"))
            {
                pasteGroupToolStripMenuItem.Enabled = true;
            }
            else
            {
                pasteGroupToolStripMenuItem.Enabled = false;
            }
             */
        }

        private void OnTreeviewNodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null)
                return; //this is just to be on the safe side 
            e.Node.BeginEdit();
        }

        private void OnTreeviewAfterSelect(object sender, TreeViewEventArgs e)
        {
            _mgr.KeyChain.CurrentGroup = (Group)_treeview.SelectedNode.Tag;
            _mgr.KeyChain.CurrentKeys = null;
            _mgr.KeyChain.CurrentKey = null;
            _mainForm.KeyList.LoadKeys();
        }

        private void OnTreeviewAfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node == null)
                return; //this is just to be on the safe side 
            if (e.Label != null)
            {
                // Stop editing without canceling the label change.
                e.Node.EndEdit(false);
                e.Node.Text = e.Label;
                Group g = (Group)e.Node.Tag;
                g.Title = e.Node.Text;
                _mgr.EditGroup(g);
                _mgr.KeyChain.Saved = false;
            }
            else
            {
                e.Node.EndEdit(true);
            }
        }

        private void OnGroupNew(object sender, EventArgs e)
        {
            OpenGroupDailog();
        }

        private void OnGroupEdit(object sender, EventArgs e)
        {
            OpenGroupDailog((Group)_treeview.SelectedNode.Tag);
        }

        private void OnGroupDelete(object sender, EventArgs e)
        {
            _mgr.DeleteGroup((Group)_treeview.SelectedNode.Tag);
            LoadGroups();
        }

        private void OnGroupDuplicate(object sender, EventArgs e)
        {
            Group g = (Group)_treeview.SelectedNode.Tag;
            Group newGroup = g.Clone();
            _mgr.AddGroup(newGroup);
            LoadGroups();
        }

        private void OnGroupPaste(object sender, EventArgs e)
        {
            string format = "KeyChainGroup";
            Group g;
            if (Clipboard.ContainsData(format))
            {
                g = (Group)Clipboard.GetData(format);
                _mgr.AddGroup(g.Clone());
                LoadGroups();
            }
        }

        private void OnGroupCopy(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetData("KeyChainGroup", (Group)_treeview.SelectedNode.Tag);
        }
    }
}
