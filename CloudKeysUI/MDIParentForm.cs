using CloudKeysController;
using CloudKeysModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CloudKeysUI
{
    public partial class MDIParentForm : Form
    {
        List<MainForm> _openedWindow = new List<MainForm>();
        List<string> _openedFiles = new List<string>();
        public List<string> OpenedFiles {
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
            this.Resize += MDIParentForm_Resize;

        }

        void MDIParentForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState && PreferencesMgr.Preference.TrayIcon)
            {
                myNotificationIcno.Visible = true;

                myNotificationIcno.ShowBalloonTip(500);
                this.ShowInTaskbar = false;
            }
            else
            {

            }
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

        private void NewWindow(string filename = "")
        {
            if(_openedFiles.Contains(filename)) {
                int index = _openedFiles.IndexOf(filename);
                BringFormToFront(_openedWindow[index]);
                return;
            }
            MainForm f = new MainForm();
            string resFilename = "";
            f.WindowState = _windowState;
            f.MdiParent = this;
            _openedWindow.Add(f);
            _openedFiles.Add(filename);
            if (_windowState != DefaultState)
            {
                f.StartPosition = FormStartPosition.Manual;
                f.Location = new System.Drawing.Point(_openedWindow.Count * 10, _openedWindow.Count * 10);
            }
            ToolStripMenuItem windowItem = new ToolStripMenuItem();

            if (filename == "")
            {
                f.Text = "untitled";
            }
            else
            {
                resFilename = f.OpenFile(filename);
                
            }
            if (resFilename == CloudKeysModel.KeyChain.WrongPassword)
            {

            }
            else
            {
                windowItem.Text = f.Text;
                windowItem.Tag = f;
                windowItem.Click += _menuitemWindowOpenedItem_Click;
                _menuitemWindowOpenedWindow.DropDown.Items.Add(windowItem);
                f.FormClosing += ChildClosing;
                f.Show();
            }
        }

        #region Event Handlers
        void Application_Idle(object sender, EventArgs e)
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

        private void ChildClosing(object sender, FormClosingEventArgs e)
        {
            MainForm f = (MainForm)sender;
            int index = _openedWindow.IndexOf(f);
            _openedWindow.RemoveAt(index);
            _openedFiles.RemoveAt(index);
            _menuitemWindowOpenedWindow.DropDown.Items.RemoveAt(index);
        }

        void OnDragEnter(object sender, DragEventArgs e)
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

        void OnDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.ToLower().EndsWith(".kcf"))
                {
                    NewWindow(file);
                }
            }
        }
        #region Menu Item Event Handlers
        #region Menu Item Files Event Handlers
        private void _menuitemFileNew_Click(object sender, EventArgs e)
        {
            NewWindow("");
        }

        private void _menuitemWindowOpenedItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem self = (ToolStripMenuItem)sender;
            MainForm f = (MainForm)self.Tag;
            BringFormToFront(f);
        }

        

        private void _menuitemFileOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "KCF Documents (*.kcf)|*.kcf";
            fd.Multiselect = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (fd.FileNames.Length > 1)
                {
                    _windowState = FormWindowState.Normal;
                }
                foreach (string path in fd.FileNames)
                {
                    NewWindow(path);
                }
                _windowState = DefaultState;
            }
        }

        private void _menuitemFileSaveAll_Click(object sender, EventArgs e)
        {
            foreach (MainForm f in _openedWindow)
            {
                f.SaveFile();
            }
        }

        private void _menuitemFileCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void _menuitemFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Menu Item Window Event Handlers
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
        
        #endregion

        private void MDIParentForm_MdiChildActivate(object sender, EventArgs e)
        {
            Console.Write("Childrens: " + this.MdiChildren.Length.ToString());
        }

        private void MDIParentForm_Load(object sender, EventArgs e)
        {
            PreferencesMgr.LoadFile();
        }

        private void myNotificationIcno_DoubleClick(object sender, EventArgs e)
        {
            myNotificationIcno.Visible = false;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Focus();
            //this.BringToFront();
        }

        private void _menuitemTools_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemToolPreference_Click(object sender, EventArgs e)
        {
            PreferencesForm f = new PreferencesForm();
            f.ShowDialog();
        }
        #endregion

            
 
    }
}
