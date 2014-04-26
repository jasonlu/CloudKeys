using CloudKeysController;
using CloudKeysModel;
using DropNet;
using DropNet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CloudKeysUI
{
    public partial class MDIParentForm : Form
    {
        const string _ext = ".kcf";
        List<MainForm> _openedWindow = new List<MainForm>();
        List<string> _openedFiles = new List<string>();
        public List<string> OpenedFiles
        {
            get { return _openedFiles; }
        }

        const FormWindowState DefaultState = FormWindowState.Maximized;
        FormWindowState _windowState = DefaultState;
        
        public MDIParentForm()
        {
            InitializeComponent();
            this.AllowDrop = true;
            Application.Idle += Application_Idle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += OnResize;

        }

        private void BringFormToFront(MainForm f)
        {
            bool hasMaximizedWindow = false;
            foreach (MainForm w in _openedWindow)
            {
                if (w.WindowState == FormWindowState.Maximized)
                {
                    hasMaximizedWindow = true;
                    break;
                }
            }
            if (hasMaximizedWindow)
            {
                f.WindowState = FormWindowState.Maximized;
            }
            f.Focus();
        }

        private void NewCloud(string url = "")
        {
            MainForm f = new MainForm();
            f.WindowState = _windowState;
            f.MdiParent = this;
            _openedWindow.Add(f);
            if (url != "")
            {
                _openedFiles.Add(url);
            }
            else
            {
                _openedFiles.Add("");
            }
            if (_windowState != DefaultState)
            {
                f.StartPosition = FormStartPosition.Manual;
                f.Location = new System.Drawing.Point(_openedWindow.Count * 10, _openedWindow.Count * 10);
            }
            ToolStripMenuItem windowItem = new ToolStripMenuItem();
            if (url != "")
            {
                f.KeyChainMgr.Open(url);
            }
            else
            {
                f.KeyChainMgr.NewKeyChain();
            }

            f.InitUI();
            f.Show();
        }

        
/*
        private void NewWindow(string filename = "", string filenameInCloud = "")
        {
            string displayName = filenameInCloud == "" ? filename : filenameInCloud;
            displayName = displayName == "" ? "UNTITLED" : displayName;

            if (_openedFiles.Contains(displayName))
            {
                int index = _openedFiles.IndexOf(displayName);
                BringFormToFront(_openedWindow[index]);
                return;
            }
            MainForm f = new MainForm();
            string resFilename = "";
            f.WindowState = _windowState;
            f.MdiParent = this;
            _openedWindow.Add(f);
            _openedFiles.Add(displayName);
            if (_windowState != DefaultState)
            {
                f.StartPosition = FormStartPosition.Manual;
                f.Location = new System.Drawing.Point(_openedWindow.Count * 10, _openedWindow.Count * 10);
            }
            ToolStripMenuItem windowItem = new ToolStripMenuItem();

            if (filenameInCloud != "")
            {
                resFilename = f.OpenFile(filename, filenameInCloud);
            }
            else
            {
                if (filename == "")
                {
                    f.Text = "untitled" + DateTime.Now.ToString();
                }
                else
                {
                    resFilename = f.OpenFile(filename);
                }
            }

            if (resFilename != CloudKeysModel.KeyChain.WrongPassword)
            {
                f.Text = displayName;
                windowItem.Text = displayName;
                windowItem.Tag = f;
                windowItem.Click += _menuitemWindowOpenedItem_Click;
                _menuitemWindowOpenedWindow.DropDown.Items.Add(windowItem);
                f.FormClosing += OnChildClosing;
                f.Show();
            }
        }
        */
        private void OpenLocalFiles()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "KCF Documents (*" + _ext + ")|*" + _ext + "";
            fd.Multiselect = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (fd.FileNames.Length > 1)
                {
                    _windowState = FormWindowState.Normal;
                }
                foreach (string path in fd.FileNames)
                {
                    NewCloud(path);
                }
                _windowState = DefaultState;
            }
        }

        private void OpenCloudFiles()
        {
            var meta = DropboxMgr.Client.Search(_ext);
            List<string> files = new List<string>();
            foreach (MetaData d in meta)
            {
                files.Add(d.Path);
            }
            CloudFileBrowser f = new CloudFileBrowser();
            f.Files = files;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string filename = f.Filename;
                NewCloud("dropbox://" + f.Filename);

                //string tgtPath = DropboxMgr.DownloadFileFromCloud(filename);
                //NewWindow(tgtPath, filename);                
            }
        }

        

        #region Event Handlers
        private void Application_Idle(object sender, EventArgs e)
        {
            if (_openedWindow.Count > 0)
            {
                _menuitemFileSaveAll.Enabled = 
                _menuitemWindowCascade.Enabled =
                _menuitemWindowTileHorizontally.Enabled =
                _menuitemWindowTileVertically.Enabled =
                _menuitemWindowOpenedWindow.Enabled = true;
            }
            else
            {
                _menuitemFileSaveAll.Enabled = 
                _menuitemWindowCascade.Enabled =
                _menuitemWindowTileHorizontally.Enabled =
                _menuitemWindowTileVertically.Enabled =
                _menuitemWindowOpenedWindow.Enabled = false;
            }
            myNotificationIcno.Visible = PreferencesMgr.Preference.TrayIcon;

        }

        private void OnResize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState && PreferencesMgr.Preference.TrayIcon)
            {
                myNotificationIcno.Visible = true;
                myNotificationIcno.ShowBalloonTip(500);
                this.ShowInTaskbar = false;
            }
        }

        private void OnChildClosing(object sender, FormClosingEventArgs e)
        {
            MainForm f = (MainForm)sender;
            int index = _openedWindow.IndexOf(f);
            _openedWindow.RemoveAt(index);
            _openedFiles.RemoveAt(index);
            _menuitemWindowOpenedWindow.DropDown.Items.RemoveAt(index);
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filename in files)
                {
                    if (!filename.ToLower().EndsWith(".kcf"))
                    {
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.ToLower().EndsWith(_ext))
                {
                    NewCloud(file);
                }
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            PreferencesMgr.LoadFile();
            foreach (string filename in PreferencesMgr.Preference.RecentFiles) {
            ToolStripMenuItem recentFiles = new ToolStripMenuItem();
                recentFiles.Text = filename;
                string realFilename = "";
                if (filename.Contains("dropbox://"))
                {
                    realFilename = filename.Substring(filename.IndexOf("/") + 2);
                } else
                {
                    realFilename = filename;
                }
                recentFiles.Tag = realFilename;
                recentFiles.Click += OnFileRecentFiles;
                _menuitemFileRecentFiles.DropDown.Items.Add(recentFiles);
                
            }
            if (PreferencesMgr.Preference.DropBoxToken != "")
            {
                DropboxMgr.init(PreferencesMgr.Preference.DropBoxToken, PreferencesMgr.Preference.DropBoxSecret);
            }
            else
            {
                if (DropboxMgr.DoOAuth() == DialogResult.OK)
                {
                    var accessToken = DropboxMgr.Client.GetAccessToken();
                    PreferencesMgr.Preference.DropBoxToken = accessToken.Token;
                    PreferencesMgr.Preference.DropBoxSecret = accessToken.Secret;
                    PreferencesMgr.SaveFile();
                    DropboxMgr.Client.UserLogin = new UserLogin() { Token = PreferencesMgr.Preference.DropBoxToken, Secret = PreferencesMgr.Preference.DropBoxSecret };
                }
            }

            
        }

        #region Menu Item Event Handlers
        #region Menu Item Files Event Handlers
        private void OnFileNew(object sender, EventArgs e)
        {
            NewCloud("");
        }

        private void OnFileOpen(object sender, EventArgs e)
        {
            if (PreferencesMgr.Preference.SaveToCloud)
            {
                OpenCloudFiles();
            }
            else
            {
                OpenLocalFiles();
            }
        }

        private void OnFileSaveAll(object sender, EventArgs e)
        {
            foreach (MainForm f in _openedWindow)
            {
                f.SaveFile();
            }
        }

        private void OnFileCloseAll(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void OnFileRecentFiles(object sender, EventArgs e)
        {
            ToolStripMenuItem me = (ToolStripMenuItem)sender;
            NewCloud(me.Text);
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Menu Item Window Event Handlers

        private void _menuitemWindowOpenedItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem self = (ToolStripMenuItem)sender;
            MainForm f = (MainForm)self.Tag;
            BringFormToFront(f);
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        #endregion

        #region Menu Item Help Event Handlers
        private void _menuitemHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }
        #endregion

        private void OnToolPreference(object sender, EventArgs e)
        {
            PreferencesForm f = new PreferencesForm();
            f.ShowDialog();
        }
        
        #endregion

        private void OnNotificationIconDoubleClick(object sender, EventArgs e)
        {
            myNotificationIcno.Visible = false;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }
        #endregion

    }
}
