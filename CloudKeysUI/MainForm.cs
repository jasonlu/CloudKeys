﻿using System;
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

        public void InitUI()
        {
            _rtfDetailBox.Text = "";
            _groupsTree.LoadGroups();
            _keyList.ClearKeys();
        }

        public KeyList KeyList
        {
            get { return _keyList; }
        }

        public GroupsTree GroupsTree
        {
            get { return _groupsTree; }
        }

        public RichTextBox DetailBox
        {
            get { return _rtfDetailBox; }
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
            _groupsTree.MainForm = this;
            _keyList.KeyChainMgr = _keyChainMgr;
            _keyList.MainForm = this;
            _statusBar.KeyChainMgr = _keyChainMgr;
            _statusBar.MainForm = this;
            _menuitemFileNew.Visible = false;
            _menuitemFileOpen.Visible = false;
            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (_keyChainMgr.KeyChain.CurrentKey == null)
            {
                _rtfDetailBox.Text = "";
            }
            else
            {
                UpdateDetail(_keyChainMgr.KeyChain.CurrentKey);
            }

            if (_keyChainMgr.KeyChain.Saved)
            {
                _toolbarSave.Enabled = _menuitemFileSave.Enabled = false; // _menuitemFileSaveAs.Enabled = false;
            }
            else
            {
                _toolbarSave.Enabled = _menuitemFileSave.Enabled = true; // _menuitemFileSaveAs.Enabled = true;
            }

            if (_keyChainMgr.KeyChain.CurrentGroup == null)
            {
                _menuitemEditAddKey.Enabled =
                _menuitemEditDeleteKeys.Enabled =
                _menuitemEditDuplicateKeys.Enabled =
                _menuitemEditEditKey.Enabled =
                _menuitemEditDeleteGroup.Enabled =
                _menuitemEditDuplicateGroup.Enabled =
                _menuitemEditEditGroup.Enabled = false;
            }
            else
            {
                _menuitemEditAddKey.Enabled =
                _menuitemEditDeleteKeys.Enabled =
                _menuitemEditDuplicateKeys.Enabled =
                _menuitemEditEditKey.Enabled =
                _menuitemEditDeleteGroup.Enabled =
                _menuitemEditDuplicateGroup.Enabled =
                _menuitemEditEditGroup.Enabled = true;
            }

            if (_keyChainMgr.KeyChain.CurrentKey == null)
            {
                _menuitemEditEditKey.Enabled =
                _menuitemEditDuplicateKeys.Enabled =
                _menuitemEditDeleteKeys.Enabled = false;
            }
            else
            {
                _menuitemEditEditKey.Enabled =
                _menuitemEditDuplicateKeys.Enabled =
                _menuitemEditDeleteKeys.Enabled = false;
            }
        }


        public void UpdateDetail(Key k)
        {
            if (k == (Key)_rtfDetailBox.Tag)
            {
                return;
            }
            _rtfDetailBox.Font = PreferencesMgr.Preference.Font;
            _rtfDetailBox.Text = "Title: \t\t" + k.Title + "\n" +
                "--------------------\n" +
                "URL: \t\t" + k.URL + "\n" +
                "Username: \t" + k.Username + "\n" +
                "Password: \t" + k.Password + "\n" +
                "Notes:\n" + k.Notes;
            _rtfDetailBox.Tag = k;
        }

        public string OpenFile(string url, string filenameInCloud = "")
        {
            if (promptToSave() == DialogResult.Yes)
            {
                url = _keyChainMgr.Open(url);
                if (url == "")
                {
                    // Do nothing...
                }
                else
                {
                    _groupsTree.LoadGroups();
                    this.Text = url;
                }
                return url;
            }
            return "";
        }

        private string NewFile()
        {
            if (promptToSave() == DialogResult.Yes)
            {
                _keyChainMgr.NewKeyChain();// = new KeyChainMgr();
                _groupsTree.KeyChainMgr = _keyChainMgr;
                _keyList.KeyChainMgr = _keyChainMgr;
                _statusBar.KeyChainMgr = _keyChainMgr;
                _groupsTree.LoadGroups();
                _keyList.LoadKeys();
                this.Text = "UNTITLED";
                return KeyChain.DefaultFilename;
            }
            return "";
        }

        public string OpenFile()
        {
            if (promptToSave() == DialogResult.Yes)
            {
                string filename = "";// _keyChainMgr.Load();
                if (filename == "")
                {
                    // Do nothing...
                }
                else
                {
                    _groupsTree.LoadGroups();
                    this.Text = filename;
                }
                return filename;
            }
            return "";
        }

        public void SaveFile(bool saveAs = false)
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

        private DialogResult promptToSave()
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


        #region Event Handlers
        #region Menu Item Event Handlers
        private void _menuitemFileNew_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void _menuitemFileOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void _menuitemFileSave_Click(object sender, EventArgs e)
        {
            _keyChainMgr.Save();
        }

        private void _menuitemFileSaveAs_Click(object sender, EventArgs e)
        {
            _keyChainMgr.Save(true);
        }

        private void _menuitemFilePrint_Click(object sender, EventArgs e)
        {
            _keyChainMgr.Print();
        }

        private void _menuitemFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _menuitemEditAddGroup_Click(object sender, EventArgs e)
        {
            _groupsTree.OpenGroupDailog();
        }

        private void _menuitemEditEditGroup_Click(object sender, EventArgs e)
        {
            _groupsTree.OpenGroupDailog(_keyChainMgr.KeyChain.CurrentGroup);
        }

        private void _menuitemEditDeleteGroup_Click(object sender, EventArgs e)
        {
            _keyChainMgr.DeleteGroup(_keyChainMgr.KeyChain.CurrentGroup);
            _groupsTree.LoadGroups();
        }

        private void _menuitemEditDuplicateGroup_Click(object sender, EventArgs e)
        {
            _keyChainMgr.AddGroup(KeyChainMgr.KeyChain.CurrentGroup.Clone());
            _groupsTree.LoadGroups();
        }

        private void _menuitemEditAddKey_Click(object sender, EventArgs e)
        {
            _keyList.OpenKeyDialog();
        }

        private void _menuitemEditEditKey_Click(object sender, EventArgs e)
        {
            _keyList.OpenKeyDialog(_keyChainMgr.KeyChain.CurrentKey);
        }

        private void _menuitemEditDeleteKeys_Click(object sender, EventArgs e)
        {
            _keyChainMgr.DeleteKey(_keyChainMgr.KeyChain.CurrentKeys);
            _keyList.LoadKeys();
        }

        private void _menuitemEditDuplicateKeys_Click(object sender, EventArgs e)
        {
            _keyChainMgr.AddKey(_keyChainMgr.KeyChain.CurrentKey.Clone());
            _keyList.LoadKeys();
        }

        private void _menuitemViewShowToolbar_Click(object sender, EventArgs e)
        {
            _toolbar.Visible = ((ToolStripMenuItem)sender).Checked;
        }

        private void _menuitemViewShowStatusbar_Click(object sender, EventArgs e)
        {
            _statusBar.Visible = ((ToolStripMenuItem)sender).Checked;
        }
        #endregion

        #region Toolbar Item Event Handlers
        private void _toolbarHelp_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (promptToSave() == DialogResult.Cancel)
                e.Cancel = true;
        }
        #endregion

    }
}
