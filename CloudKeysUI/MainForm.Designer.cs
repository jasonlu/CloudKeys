﻿namespace CloudKeysUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CloudKeysController.KeyChainMgr keyChainMgr1 = new CloudKeysController.KeyChainMgr();
            CloudKeysModel.KeyChain keyChain1 = new CloudKeysModel.KeyChain();
            CloudKeysController.KeyChainMgr keyChainMgr2 = new CloudKeysController.KeyChainMgr();
            CloudKeysModel.KeyChain keyChain2 = new CloudKeysModel.KeyChain();
            this._toolbar = new System.Windows.Forms.ToolStrip();
            this._toolbarNewFile = new System.Windows.Forms.ToolStripButton();
            this._toolbarOpenFile = new System.Windows.Forms.ToolStripButton();
            this._toolbarSave = new System.Windows.Forms.ToolStripButton();
            this._toolbarPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._toolbarHelp = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._menuitemFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._menuitemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemEditAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemEditEditGroup = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemEditDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemEditDuplicateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._menuitemEditAddKey = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemEditEditKey = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemEditDeleteKeys = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemEditDuplicateKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemViewShowToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemViewShowStatusbar = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._rtfDetailBox = new System.Windows.Forms.RichTextBox();
            this._groupsTree = new CloudKeysUI.GroupsTree();
            this._keyList = new CloudKeysUI.KeyList();
            this._statusBar = new CloudKeysUI.StatusBar();
            this._toolbar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolbar
            // 
            this._toolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolbarNewFile,
            this._toolbarOpenFile,
            this._toolbarSave,
            this._toolbarPrint,
            this.toolStripSeparator1,
            this._toolbarHelp});
            this._toolbar.Location = new System.Drawing.Point(0, 25);
            this._toolbar.Name = "_toolbar";
            this._toolbar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this._toolbar.Size = new System.Drawing.Size(1073, 31);
            this._toolbar.TabIndex = 0;
            this._toolbar.Text = "toolStrip1";
            // 
            // _toolbarNewFile
            // 
            this._toolbarNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarNewFile.Image = global::CloudKeysUI.Properties.Resources.New;
            this._toolbarNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarNewFile.Name = "_toolbarNewFile";
            this._toolbarNewFile.Size = new System.Drawing.Size(28, 28);
            this._toolbarNewFile.Text = "toolStripButton1";
            this._toolbarNewFile.Click += new System.EventHandler(this._menuitemFileNew_Click);
            // 
            // _toolbarOpenFile
            // 
            this._toolbarOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarOpenFile.Image = global::CloudKeysUI.Properties.Resources.Open;
            this._toolbarOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarOpenFile.Name = "_toolbarOpenFile";
            this._toolbarOpenFile.Size = new System.Drawing.Size(28, 28);
            this._toolbarOpenFile.Text = "toolStripButton2";
            this._toolbarOpenFile.Click += new System.EventHandler(this._menuitemFileOpen_Click);
            // 
            // _toolbarSave
            // 
            this._toolbarSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarSave.Image = global::CloudKeysUI.Properties.Resources.Save;
            this._toolbarSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarSave.Name = "_toolbarSave";
            this._toolbarSave.Size = new System.Drawing.Size(28, 28);
            this._toolbarSave.Text = "toolStripButton3";
            this._toolbarSave.Click += new System.EventHandler(this._menuitemFileSave_Click);
            // 
            // _toolbarPrint
            // 
            this._toolbarPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarPrint.Image = global::CloudKeysUI.Properties.Resources.Print;
            this._toolbarPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarPrint.Name = "_toolbarPrint";
            this._toolbarPrint.Size = new System.Drawing.Size(28, 28);
            this._toolbarPrint.Text = "toolStripButton4";
            this._toolbarPrint.Click += new System.EventHandler(this._menuitemFilePrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // _toolbarHelp
            // 
            this._toolbarHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarHelp.Image = global::CloudKeysUI.Properties.Resources.Help;
            this._toolbarHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarHelp.Name = "_toolbarHelp";
            this._toolbarHelp.Size = new System.Drawing.Size(28, 28);
            this._toolbarHelp.Text = "toolStripButton5";
            this._toolbarHelp.Click += new System.EventHandler(this._toolbarHelp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1073, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemFileNew,
            this._menuitemFileOpen,
            this.toolStripSeparator2,
            this._menuitemFileSave,
            this._menuitemFileSaveAs,
            this._menuitemFilePrint,
            this.toolStripSeparator3,
            this._menuitemFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // _menuitemFileNew
            // 
            this._menuitemFileNew.Name = "_menuitemFileNew";
            this._menuitemFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._menuitemFileNew.Size = new System.Drawing.Size(184, 22);
            this._menuitemFileNew.Text = "New";
            this._menuitemFileNew.Click += new System.EventHandler(this._menuitemFileNew_Click);
            // 
            // _menuitemFileOpen
            // 
            this._menuitemFileOpen.Name = "_menuitemFileOpen";
            this._menuitemFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._menuitemFileOpen.Size = new System.Drawing.Size(184, 22);
            this._menuitemFileOpen.Text = "Open";
            this._menuitemFileOpen.Click += new System.EventHandler(this._menuitemFileOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // _menuitemFileSave
            // 
            this._menuitemFileSave.Name = "_menuitemFileSave";
            this._menuitemFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._menuitemFileSave.Size = new System.Drawing.Size(184, 22);
            this._menuitemFileSave.Text = "Save";
            this._menuitemFileSave.Click += new System.EventHandler(this._menuitemFileSave_Click);
            // 
            // _menuitemFileSaveAs
            // 
            this._menuitemFileSaveAs.Name = "_menuitemFileSaveAs";
            this._menuitemFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this._menuitemFileSaveAs.Size = new System.Drawing.Size(184, 22);
            this._menuitemFileSaveAs.Text = "Save as";
            this._menuitemFileSaveAs.Click += new System.EventHandler(this._menuitemFileSaveAs_Click);
            // 
            // _menuitemFilePrint
            // 
            this._menuitemFilePrint.Name = "_menuitemFilePrint";
            this._menuitemFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this._menuitemFilePrint.Size = new System.Drawing.Size(184, 22);
            this._menuitemFilePrint.Text = "Print";
            this._menuitemFilePrint.Click += new System.EventHandler(this._menuitemFilePrint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // _menuitemFileExit
            // 
            this._menuitemFileExit.Name = "_menuitemFileExit";
            this._menuitemFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this._menuitemFileExit.Size = new System.Drawing.Size(184, 22);
            this._menuitemFileExit.Text = "Close";
            this._menuitemFileExit.Click += new System.EventHandler(this._menuitemFileExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemEditAddGroup,
            this._menuitemEditEditGroup,
            this._menuitemEditDeleteGroup,
            this._menuitemEditDuplicateGroup,
            this.toolStripSeparator4,
            this._menuitemEditAddKey,
            this._menuitemEditEditKey,
            this._menuitemEditDeleteKeys,
            this._menuitemEditDuplicateKeys});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // _menuitemEditAddGroup
            // 
            this._menuitemEditAddGroup.Image = global::CloudKeysUI.Properties.Resources.Folder;
            this._menuitemEditAddGroup.Name = "_menuitemEditAddGroup";
            this._menuitemEditAddGroup.Size = new System.Drawing.Size(160, 22);
            this._menuitemEditAddGroup.Text = "Add Group";
            this._menuitemEditAddGroup.Click += new System.EventHandler(this._menuitemEditAddGroup_Click);
            // 
            // _menuitemEditEditGroup
            // 
            this._menuitemEditEditGroup.Image = global::CloudKeysUI.Properties.Resources.Folder_blue;
            this._menuitemEditEditGroup.Name = "_menuitemEditEditGroup";
            this._menuitemEditEditGroup.Size = new System.Drawing.Size(160, 22);
            this._menuitemEditEditGroup.Text = "Edit Group";
            this._menuitemEditEditGroup.Click += new System.EventHandler(this._menuitemEditEditGroup_Click);
            // 
            // _menuitemEditDeleteGroup
            // 
            this._menuitemEditDeleteGroup.Image = global::CloudKeysUI.Properties.Resources.Delete;
            this._menuitemEditDeleteGroup.Name = "_menuitemEditDeleteGroup";
            this._menuitemEditDeleteGroup.Size = new System.Drawing.Size(160, 22);
            this._menuitemEditDeleteGroup.Text = "Delete Group";
            this._menuitemEditDeleteGroup.Click += new System.EventHandler(this._menuitemEditDeleteGroup_Click);
            // 
            // _menuitemEditDuplicateGroup
            // 
            this._menuitemEditDuplicateGroup.Name = "_menuitemEditDuplicateGroup";
            this._menuitemEditDuplicateGroup.Size = new System.Drawing.Size(160, 22);
            this._menuitemEditDuplicateGroup.Text = "Duplicate Group";
            this._menuitemEditDuplicateGroup.Click += new System.EventHandler(this._menuitemEditDuplicateGroup_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // _menuitemEditAddKey
            // 
            this._menuitemEditAddKey.Image = global::CloudKeysUI.Properties.Resources.Entry;
            this._menuitemEditAddKey.Name = "_menuitemEditAddKey";
            this._menuitemEditAddKey.Size = new System.Drawing.Size(160, 22);
            this._menuitemEditAddKey.Text = "Add Key";
            this._menuitemEditAddKey.Click += new System.EventHandler(this._menuitemEditAddKey_Click);
            // 
            // _menuitemEditEditKey
            // 
            this._menuitemEditEditKey.Image = global::CloudKeysUI.Properties.Resources.Edit;
            this._menuitemEditEditKey.Name = "_menuitemEditEditKey";
            this._menuitemEditEditKey.Size = new System.Drawing.Size(160, 22);
            this._menuitemEditEditKey.Text = "Edit Key";
            this._menuitemEditEditKey.Click += new System.EventHandler(this._menuitemEditEditKey_Click);
            // 
            // _menuitemEditDeleteKeys
            // 
            this._menuitemEditDeleteKeys.Image = global::CloudKeysUI.Properties.Resources.Delete;
            this._menuitemEditDeleteKeys.Name = "_menuitemEditDeleteKeys";
            this._menuitemEditDeleteKeys.Size = new System.Drawing.Size(160, 22);
            this._menuitemEditDeleteKeys.Text = "Delete Keys";
            this._menuitemEditDeleteKeys.Click += new System.EventHandler(this._menuitemEditDeleteKeys_Click);
            // 
            // _menuitemEditDuplicateKeys
            // 
            this._menuitemEditDuplicateKeys.Image = global::CloudKeysUI.Properties.Resources.DuplicateKey;
            this._menuitemEditDuplicateKeys.Name = "_menuitemEditDuplicateKeys";
            this._menuitemEditDuplicateKeys.Size = new System.Drawing.Size(160, 22);
            this._menuitemEditDuplicateKeys.Text = "Duplicate Keys";
            this._menuitemEditDuplicateKeys.Click += new System.EventHandler(this._menuitemEditDuplicateKeys_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemViewShowToolbar,
            this._menuitemViewShowStatusbar});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // _menuitemViewShowToolbar
            // 
            this._menuitemViewShowToolbar.Checked = true;
            this._menuitemViewShowToolbar.CheckOnClick = true;
            this._menuitemViewShowToolbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this._menuitemViewShowToolbar.Name = "_menuitemViewShowToolbar";
            this._menuitemViewShowToolbar.Size = new System.Drawing.Size(155, 22);
            this._menuitemViewShowToolbar.Text = "Show Toolbar";
            this._menuitemViewShowToolbar.Click += new System.EventHandler(this._menuitemViewShowToolbar_Click);
            // 
            // _menuitemViewShowStatusbar
            // 
            this._menuitemViewShowStatusbar.Checked = true;
            this._menuitemViewShowStatusbar.CheckOnClick = true;
            this._menuitemViewShowStatusbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this._menuitemViewShowStatusbar.Name = "_menuitemViewShowStatusbar";
            this._menuitemViewShowStatusbar.Size = new System.Drawing.Size(155, 22);
            this._menuitemViewShowStatusbar.Text = "Show Statusbar";
            this._menuitemViewShowStatusbar.Click += new System.EventHandler(this._menuitemViewShowStatusbar_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::CloudKeysUI.Properties.Resources.Help;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._groupsTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1073, 463);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._keyList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._rtfDetailBox);
            this.splitContainer2.Size = new System.Drawing.Size(712, 463);
            this.splitContainer2.SplitterDistance = 237;
            this.splitContainer2.TabIndex = 0;
            // 
            // _rtfDetailBox
            // 
            this._rtfDetailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtfDetailBox.Location = new System.Drawing.Point(0, 0);
            this._rtfDetailBox.Margin = new System.Windows.Forms.Padding(0);
            this._rtfDetailBox.Name = "_rtfDetailBox";
            this._rtfDetailBox.ReadOnly = true;
            this._rtfDetailBox.Size = new System.Drawing.Size(710, 220);
            this._rtfDetailBox.TabIndex = 0;
            this._rtfDetailBox.Text = "";
            // 
            // _groupsTree
            // 
            this._groupsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            keyChain1.CurrentGroup = null;
            keyChain1.CurrentKey = null;
            keyChain1.Filename = "?\\NEWFILE\\?";
            keyChain1.Saved = false;
            keyChainMgr1.KeyChain = keyChain1;
            this._groupsTree.KeyChainMgr = keyChainMgr1;
            this._groupsTree.Location = new System.Drawing.Point(0, 0);
            this._groupsTree.MainForm = null;
            this._groupsTree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._groupsTree.Name = "_groupsTree";
            this._groupsTree.Size = new System.Drawing.Size(355, 461);
            this._groupsTree.TabIndex = 0;
            // 
            // _keyList
            // 
            this._keyList.Dock = System.Windows.Forms.DockStyle.Fill;
            keyChain2.CurrentGroup = null;
            keyChain2.CurrentKey = null;
            keyChain2.Filename = "?\\NEWFILE\\?";
            keyChain2.Saved = false;
            keyChainMgr2.KeyChain = keyChain2;
            this._keyList.KeyChainMgr = keyChainMgr2;
            this._keyList.Location = new System.Drawing.Point(0, 0);
            this._keyList.MainForm = null;
            this._keyList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._keyList.Name = "_keyList";
            this._keyList.Size = new System.Drawing.Size(710, 235);
            this._keyList.TabIndex = 0;
            // 
            // _statusBar
            // 
            this._statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._statusBar.Location = new System.Drawing.Point(0, 519);
            this._statusBar.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this._statusBar.Name = "_statusBar";
            this._statusBar.Size = new System.Drawing.Size(1073, 42);
            this._statusBar.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._toolbar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this._statusBar);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this._toolbar.ResumeLayout(false);
            this._toolbar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolbar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _toolbarNewFile;
        private System.Windows.Forms.ToolStripButton _toolbarOpenFile;
        private System.Windows.Forms.ToolStripButton _toolbarSave;
        private System.Windows.Forms.ToolStripButton _toolbarPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _toolbarHelp;
        private StatusBar _statusBar;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileNew;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileSave;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFilePrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileExit;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditAddGroup;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditEditGroup;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditDeleteGroup;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditDuplicateGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditAddKey;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditEditKey;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditDeleteKeys;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditDuplicateKeys;
        private System.Windows.Forms.ToolStripMenuItem _menuitemViewShowToolbar;
        private System.Windows.Forms.ToolStripMenuItem _menuitemViewShowStatusbar;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GroupsTree _groupsTree;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private KeyList _keyList;
        private System.Windows.Forms.RichTextBox _rtfDetailBox;
    }
}