using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CloudKeysUI
{
    public partial class MDIParentForm : Form
    {
        List<MainForm> _openedWindow = new List<MainForm>();
        public MDIParentForm()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void NewWindow(string filename)
        {
            MainForm f = new MainForm();
            f.MdiParent = this;
            _openedWindow.Add(f);
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new System.Drawing.Point(_openedWindow.Count * 10, _openedWindow.Count * 10);
            ToolStripMenuItem windowItem = new ToolStripMenuItem();

            if (filename == "")
            {
                f.Text = "untitled";
            }
            else
            {
                f.OpenFile(filename);
            }
            windowItem.Text = f.Text;
            windowItem.Tag = f;
            windowItem.Click += _menuitemWindowOpenedItem_Click;
            _menuitemWindowOpenedWindow.DropDown.Items.Add(windowItem);

            f.Show();
        }

        #region Event Handlers
        void Application_Idle(object sender, EventArgs e)
        {
            if (_openedWindow.Count > 0)
            {
                _menuitemWindowCascade.Enabled =
                _menuitemWindowTileHorizontally.Enabled =
                _menuitemWindowTileVertically.Enabled =
                _menuitemWindowOpenedWindow.Enabled = true;
            }
            else
            {
                _menuitemWindowCascade.Enabled =
                _menuitemWindowTileHorizontally.Enabled =
                _menuitemWindowTileVertically.Enabled =
                _menuitemWindowOpenedWindow.Enabled = false;
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
            f.Focus();
        }

        private void _menuitemFileOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "KCF Documents (*.kcf)|*.kcf";
            fd.Multiselect = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                foreach (string path in fd.FileNames)
                {
                    NewWindow(path);
                }
            }
        }

        private void _menuitemFileSaveAll_Click(object sender, EventArgs e)
        {

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

        }
        #endregion
        
        #endregion

        private void MDIParentForm_MdiChildActivate(object sender, EventArgs e)
        {
            Console.Write("Childrens: " + this.MdiChildren.Length.ToString());
        }
        #endregion

        
    }
}
