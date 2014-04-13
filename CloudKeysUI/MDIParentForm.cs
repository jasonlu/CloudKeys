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

        private void _menuitemFileNew_Click(object sender, EventArgs e)
        {
            NewWindow();
        }

        private void NewWindow(string filename = null)
        {
            MainForm f = new MainForm();
            f.MdiParent = this;
            _openedWindow.Add(f);
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new System.Drawing.Point(_openedWindow.Count * 10, _openedWindow.Count * 10);
            ToolStripMenuItem windowItem = new ToolStripMenuItem();
            string title = "";
            if (filename == null)
            {
                title = "untitled";
            }
            else
            {
                title = filename.Substring(filename.LastIndexOf("\\") + 1);
            }
            f.Text = title;
            windowItem.Text = title;
            windowItem.Tag = f;
            windowItem.Click += _menuitemWindowOpenedItem_Click;
            _menuitemWindowOpenedWindow.DropDown.Items.Add(windowItem);

            f.Show();
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
            fd.DefaultExt = "*.kcf";
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void _menuitemFileCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void MDIParentForm_MdiChildActivate(object sender, EventArgs e)
        {
            Console.Write("Childrens: " + this.MdiChildren.Length.ToString());
        }
    }
}
