namespace CloudKeysUI
{
    partial class GroupsTree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._toolbarNewGroup = new System.Windows.Forms.ToolStripButton();
            this._toolbarEditGroup = new System.Windows.Forms.ToolStripButton();
            this._toolbarDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this._treeview = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolbarNewGroup,
            this._toolbarEditGroup,
            this._toolbarDeleteGroup});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(30, 785);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _toolbarNewGroup
            // 
            this._toolbarNewGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarNewGroup.Image = global::CloudKeysUI.Properties.Resources.Folder;
            this._toolbarNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarNewGroup.Name = "_toolbarNewGroup";
            this._toolbarNewGroup.Size = new System.Drawing.Size(25, 28);
            this._toolbarNewGroup.Text = "toolStripButton1";
            this._toolbarNewGroup.Click += new System.EventHandler(this.OnGroupNew);
            // 
            // _toolbarEditGroup
            // 
            this._toolbarEditGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarEditGroup.Enabled = false;
            this._toolbarEditGroup.Image = global::CloudKeysUI.Properties.Resources.Folder_blue;
            this._toolbarEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarEditGroup.Name = "_toolbarEditGroup";
            this._toolbarEditGroup.Size = new System.Drawing.Size(25, 28);
            this._toolbarEditGroup.Text = "toolStripButton2";
            this._toolbarEditGroup.Click += new System.EventHandler(this.OnGroupEdit);
            // 
            // _toolbarDeleteGroup
            // 
            this._toolbarDeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarDeleteGroup.Enabled = false;
            this._toolbarDeleteGroup.Image = global::CloudKeysUI.Properties.Resources.Delete;
            this._toolbarDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarDeleteGroup.Name = "_toolbarDeleteGroup";
            this._toolbarDeleteGroup.Size = new System.Drawing.Size(25, 28);
            this._toolbarDeleteGroup.Text = "toolStripButton3";
            this._toolbarDeleteGroup.Click += new System.EventHandler(this.OnGroupDelete);
            // 
            // _treeview
            // 
            this._treeview.ContextMenuStrip = this.contextMenuStrip1;
            this._treeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeview.LabelEdit = true;
            this._treeview.Location = new System.Drawing.Point(30, 0);
            this._treeview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._treeview.Name = "_treeview";
            this._treeview.Size = new System.Drawing.Size(434, 785);
            this._treeview.TabIndex = 1;
            this._treeview.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.OnTreeviewAfterLabelEdit);
            this._treeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeviewAfterSelect);
            this._treeview.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnTreeviewNodeDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyGroupToolStripMenuItem,
            this.pasteGroupToolStripMenuItem,
            this.duplicateGroupToolStripMenuItem,
            this.deleteGroupToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 114);
            // 
            // copyGroupToolStripMenuItem
            // 
            this.copyGroupToolStripMenuItem.Enabled = false;
            this.copyGroupToolStripMenuItem.Name = "copyGroupToolStripMenuItem";
            this.copyGroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyGroupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.copyGroupToolStripMenuItem.Text = "Copy group";
            this.copyGroupToolStripMenuItem.Click += new System.EventHandler(this.OnGroupCopy);
            // 
            // pasteGroupToolStripMenuItem
            // 
            this.pasteGroupToolStripMenuItem.Enabled = false;
            this.pasteGroupToolStripMenuItem.Name = "pasteGroupToolStripMenuItem";
            this.pasteGroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteGroupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.pasteGroupToolStripMenuItem.Text = "Paste group";
            this.pasteGroupToolStripMenuItem.Click += new System.EventHandler(this.OnGroupPaste);
            // 
            // duplicateGroupToolStripMenuItem
            // 
            this.duplicateGroupToolStripMenuItem.Enabled = false;
            this.duplicateGroupToolStripMenuItem.Name = "duplicateGroupToolStripMenuItem";
            this.duplicateGroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateGroupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.duplicateGroupToolStripMenuItem.Text = "Duplicate group";
            this.duplicateGroupToolStripMenuItem.Click += new System.EventHandler(this.OnGroupDuplicate);
            // 
            // deleteGroupToolStripMenuItem
            // 
            this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            this.deleteGroupToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.deleteGroupToolStripMenuItem.Text = "Delete group";
            this.deleteGroupToolStripMenuItem.Click += new System.EventHandler(this.OnGroupDelete);
            // 
            // GroupsTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._treeview);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GroupsTree";
            this.Size = new System.Drawing.Size(464, 785);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TreeView _treeview;
        private System.Windows.Forms.ToolStripButton _toolbarNewGroup;
        private System.Windows.Forms.ToolStripButton _toolbarEditGroup;
        private System.Windows.Forms.ToolStripButton _toolbarDeleteGroup;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
    }
}
