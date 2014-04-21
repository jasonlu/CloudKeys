using System;
using System.Windows.Forms;
using CloudKeysModel;
using CloudKeysController;

namespace CloudKeysUI
{
    public partial class MainForm : Form
    {

        private CloudKeysController.KeyChainMgr _keyChainMgr;
        public CloudKeysController.KeyChainMgr KeyChainMgr
        {
            set { this._keyChainMgr = value; }
            get { return this._keyChainMgr; }
        }

        public MainForm()
        {
            InitializeComponent();
            if (this.Tag == null)
            {
                _keyChainMgr = new KeyChainMgr();
            }
            else
            {
                _keyChainMgr = (CloudKeysController.KeyChainMgr)this.Tag;
            }
            _groupsTree.KeyChainMgr = _keyChainMgr;
            _keyList.KeyChainMgr = _keyChainMgr;
        }

        public void Load(string filename)
        {
            openFile(filename);
        }

        public void Load()
        {
            openFile();
        }

        private void _menuitemFileNew_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemFileOpen_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFile(string filename)
        {
            if (promptToSave() == DialogResult.Yes)
            {
                filename = _keyChainMgr.Load(filename);
                if (filename == "")
                {
                    // Do nothing...
                }
                else
                {
                    _groupsTree.LoadGroups();
                    this.Text = filename;
                }
            }
        }



        private void openFile()
        {
            if (promptToSave() == DialogResult.Yes)
            {
                string filename = _keyChainMgr.Load();
                if (filename == "")
                {
                    // Do nothing...
                }
                else
                {
                    _groupsTree.LoadGroups();
                    this.Text = filename;
                }
            }
        }

        private void saveFile(bool saveAs = false)
        {
            string filename = _keyChainMgr.Save(saveAs);
            if (filename == "")
            {
                // Do nothing...
            }
            else
            {
                this.Text = filename;
            }
        }
        private void _menuitemFileSave_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void _menuitemFileSaveAs_Click(object sender, EventArgs e)
        {
            saveFile(true);
        }

        private void _menuitemFilePrint_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _menuitemEditAddGroup_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemEditEditGroup_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemEditDeleteGroup_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemEditDuplicateGroup_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemEditAddKey_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemEditEditKey_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemEditDeleteKeys_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemEditDuplicateKeys_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemViewShowToolbar_Click(object sender, EventArgs e)
        {
            _toolbar.Visible = ((ToolStripMenuItem)sender).Checked;
        }

        private void _menuitemViewShowStatusbar_Click(object sender, EventArgs e)
        {
            _statusBar.Visible = ((ToolStripMenuItem)sender).Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void _toolbarNewFile_Click(object sender, EventArgs e)
        {

        }

        private void _toolbarOpenFile_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void _toolbarSave_Click(object sender, EventArgs e)
        {
            _keyChainMgr.Save();
        }

        private void _toolbarPrint_Click(object sender, EventArgs e)
        {

        }

        private void _toolbarHelp_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (promptToSave() == DialogResult.Cancel)
                e.Cancel = true;
        }

        private System.Windows.Forms.DialogResult promptToSave()
        {
            if (!_keyChainMgr.KeyChain.Saved && _keyChainMgr.KeyChain.Filename != "?\\NEWFILE\\?")
            {
                DialogResult dr = MessageBox.Show("Everythin not saved will be lost, do you want to save?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string path = _keyChainMgr.Save();
                    if (path == "")
                    {
                        return DialogResult.Cancel;
                    }
                    else
                    {
                        return DialogResult.Yes;
                    }
                }
                else if (dr == DialogResult.Cancel)
                {
                    return DialogResult.Cancel;
                }
                else
                {
                    return DialogResult.Yes;
                    // go ahead and close thie window
                }
            }
            else
            {
                return DialogResult.Yes;
            }
        }


    }
}
