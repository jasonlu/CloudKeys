namespace CloudKeysUI
{
    partial class MDIParentForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParentForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemFileSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._menuitemFileCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemWindowTileHorizontally = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemWindowTileVertically = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemWindowCascade = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemWindowOpenedWindow = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemTools = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemToolPreference = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.myNotificationIcno = new System.Windows.Forms.NotifyIcon(this.components);
            this._menuitemFileRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem,
            this._menuitemTools,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemFileNew,
            this._menuitemFileOpen,
            this._menuitemFileRecentFiles,
            this._menuitemFileSaveAll,
            this.toolStripSeparator1,
            this._menuitemFileCloseAll,
            this._menuitemFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // _menuitemFileNew
            // 
            this._menuitemFileNew.Name = "_menuitemFileNew";
            this._menuitemFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._menuitemFileNew.Size = new System.Drawing.Size(210, 22);
            this._menuitemFileNew.Text = "New";
            this._menuitemFileNew.Click += new System.EventHandler(this.OnFileNew);
            // 
            // _menuitemFileOpen
            // 
            this._menuitemFileOpen.Name = "_menuitemFileOpen";
            this._menuitemFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._menuitemFileOpen.Size = new System.Drawing.Size(210, 22);
            this._menuitemFileOpen.Text = "Open";
            this._menuitemFileOpen.Click += new System.EventHandler(this.OnFileOpen);
            // 
            // _menuitemFileSaveAll
            // 
            this._menuitemFileSaveAll.Name = "_menuitemFileSaveAll";
            this._menuitemFileSaveAll.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this._menuitemFileSaveAll.Size = new System.Drawing.Size(210, 22);
            this._menuitemFileSaveAll.Text = "Save All";
            this._menuitemFileSaveAll.Click += new System.EventHandler(this.OnFileSaveAll);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // _menuitemFileCloseAll
            // 
            this._menuitemFileCloseAll.Name = "_menuitemFileCloseAll";
            this._menuitemFileCloseAll.Size = new System.Drawing.Size(210, 22);
            this._menuitemFileCloseAll.Text = "Close All";
            this._menuitemFileCloseAll.Click += new System.EventHandler(this.OnFileCloseAll);
            // 
            // _menuitemFileExit
            // 
            this._menuitemFileExit.Name = "_menuitemFileExit";
            this._menuitemFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._menuitemFileExit.Size = new System.Drawing.Size(210, 22);
            this._menuitemFileExit.Text = "Exit";
            this._menuitemFileExit.Click += new System.EventHandler(this.OnFileExit);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemWindowTileHorizontally,
            this._menuitemWindowTileVertically,
            this._menuitemWindowCascade,
            this._menuitemWindowOpenedWindow});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // _menuitemWindowTileHorizontally
            // 
            this._menuitemWindowTileHorizontally.Enabled = false;
            this._menuitemWindowTileHorizontally.Name = "_menuitemWindowTileHorizontally";
            this._menuitemWindowTileHorizontally.Size = new System.Drawing.Size(163, 22);
            this._menuitemWindowTileHorizontally.Text = "Tile Horizontally";
            this._menuitemWindowTileHorizontally.Click += new System.EventHandler(this.tileHorizontallyToolStripMenuItem_Click);
            // 
            // _menuitemWindowTileVertically
            // 
            this._menuitemWindowTileVertically.Enabled = false;
            this._menuitemWindowTileVertically.Name = "_menuitemWindowTileVertically";
            this._menuitemWindowTileVertically.Size = new System.Drawing.Size(163, 22);
            this._menuitemWindowTileVertically.Text = "Tile Vertically";
            this._menuitemWindowTileVertically.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem_Click);
            // 
            // _menuitemWindowCascade
            // 
            this._menuitemWindowCascade.Enabled = false;
            this._menuitemWindowCascade.Name = "_menuitemWindowCascade";
            this._menuitemWindowCascade.Size = new System.Drawing.Size(163, 22);
            this._menuitemWindowCascade.Text = "Cascade";
            this._menuitemWindowCascade.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // _menuitemWindowOpenedWindow
            // 
            this._menuitemWindowOpenedWindow.Enabled = false;
            this._menuitemWindowOpenedWindow.Name = "_menuitemWindowOpenedWindow";
            this._menuitemWindowOpenedWindow.Size = new System.Drawing.Size(163, 22);
            this._menuitemWindowOpenedWindow.Text = "Opened Window";
            // 
            // _menuitemTools
            // 
            this._menuitemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemToolPreference});
            this._menuitemTools.Name = "_menuitemTools";
            this._menuitemTools.Size = new System.Drawing.Size(48, 20);
            this._menuitemTools.Text = "Tools";
            // 
            // _menuitemToolPreference
            // 
            this._menuitemToolPreference.Name = "_menuitemToolPreference";
            this._menuitemToolPreference.Size = new System.Drawing.Size(135, 22);
            this._menuitemToolPreference.Text = "Preferences";
            this._menuitemToolPreference.Click += new System.EventHandler(this.OnToolPreference);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemHelpAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // _menuitemHelpAbout
            // 
            this._menuitemHelpAbout.Name = "_menuitemHelpAbout";
            this._menuitemHelpAbout.Size = new System.Drawing.Size(107, 22);
            this._menuitemHelpAbout.Text = "About";
            this._menuitemHelpAbout.Click += new System.EventHandler(this._menuitemHelpAbout_Click);
            // 
            // myNotificationIcno
            // 
            this.myNotificationIcno.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.myNotificationIcno.BalloonTipText = "CloudKey App is not yet close.";
            this.myNotificationIcno.BalloonTipTitle = "Still here.";
            this.myNotificationIcno.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotificationIcno.Icon")));
            this.myNotificationIcno.Text = "notifyIcon1";
            this.myNotificationIcno.Visible = true;
            this.myNotificationIcno.DoubleClick += new System.EventHandler(this.OnNotificationIconDoubleClick);
            // 
            // recentFilesToolStripMenuItem
            // 
            this._menuitemFileRecentFiles.Name = "_menuitemFileRecentFiles";
            this._menuitemFileRecentFiles.Size = new System.Drawing.Size(210, 22);
            this._menuitemFileRecentFiles.Text = "Recent Files";
            // 
            // MDIParentForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 480);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIParentForm";
            this.Text = "CloudKeys";
            this.Load += new System.EventHandler(this.OnLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileNew;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileOpen;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileExit;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuitemWindowTileHorizontally;
        private System.Windows.Forms.ToolStripMenuItem _menuitemWindowTileVertically;
        private System.Windows.Forms.ToolStripMenuItem _menuitemWindowCascade;
        private System.Windows.Forms.ToolStripMenuItem _menuitemWindowOpenedWindow;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuitemHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileCloseAll;
        private System.Windows.Forms.ToolStripMenuItem _menuitemTools;
        private System.Windows.Forms.ToolStripMenuItem _menuitemToolPreference;
        private System.Windows.Forms.NotifyIcon myNotificationIcno;
        private System.Windows.Forms.ToolStripMenuItem _menuitemFileRecentFiles;
    }
}