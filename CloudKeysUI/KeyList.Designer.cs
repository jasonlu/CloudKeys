namespace CloudKeysUI
{
    partial class KeyList
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
            this._listview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._contextMenuCopyKeys = new System.Windows.Forms.ToolStripMenuItem();
            this._contextMenuPasteKeys = new System.Windows.Forms.ToolStripMenuItem();
            this._contextMenuDuplicateKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._contextMenuNewKey = new System.Windows.Forms.ToolStripMenuItem();
            this._contextMenuEditKey = new System.Windows.Forms.ToolStripMenuItem();
            this._contextMenuDeleteKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._toolbarNewKey = new System.Windows.Forms.ToolStripButton();
            this._toolbarEditKey = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._toobarDeleteKeys = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _listview
            // 
            this._listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this._listview.ContextMenuStrip = this.contextMenuStrip1;
            this._listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listview.GridLines = true;
            this._listview.Location = new System.Drawing.Point(0, 31);
            this._listview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._listview.Name = "_listview";
            this._listview.Size = new System.Drawing.Size(969, 607);
            this._listview.TabIndex = 0;
            this._listview.UseCompatibleStateImageBehavior = false;
            this._listview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "URL";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Username";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Password";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._contextMenuCopyKeys,
            this._contextMenuPasteKeys,
            this._contextMenuDuplicateKeys,
            this.toolStripSeparator2,
            this._contextMenuNewKey,
            this._contextMenuEditKey,
            this._contextMenuDeleteKeys});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 142);
            // 
            // _contextMenuCopyKeys
            // 
            this._contextMenuCopyKeys.Enabled = false;
            this._contextMenuCopyKeys.Name = "_contextMenuCopyKeys";
            this._contextMenuCopyKeys.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this._contextMenuCopyKeys.Size = new System.Drawing.Size(192, 22);
            this._contextMenuCopyKeys.Text = "Copy keys";
            // 
            // _contextMenuPasteKeys
            // 
            this._contextMenuPasteKeys.Enabled = false;
            this._contextMenuPasteKeys.Name = "_contextMenuPasteKeys";
            this._contextMenuPasteKeys.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this._contextMenuPasteKeys.Size = new System.Drawing.Size(192, 22);
            this._contextMenuPasteKeys.Text = "Paste keys";
            // 
            // _contextMenuDuplicateKeys
            // 
            this._contextMenuDuplicateKeys.Enabled = false;
            this._contextMenuDuplicateKeys.Name = "_contextMenuDuplicateKeys";
            this._contextMenuDuplicateKeys.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this._contextMenuDuplicateKeys.Size = new System.Drawing.Size(192, 22);
            this._contextMenuDuplicateKeys.Text = "Duplicate keys";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // _contextMenuNewKey
            // 
            this._contextMenuNewKey.Enabled = false;
            this._contextMenuNewKey.Name = "_contextMenuNewKey";
            this._contextMenuNewKey.Size = new System.Drawing.Size(192, 22);
            this._contextMenuNewKey.Text = "New key";
            // 
            // _contextMenuEditKey
            // 
            this._contextMenuEditKey.Enabled = false;
            this._contextMenuEditKey.Name = "_contextMenuEditKey";
            this._contextMenuEditKey.Size = new System.Drawing.Size(192, 22);
            this._contextMenuEditKey.Text = "Edit Key";
            // 
            // _contextMenuDeleteKeys
            // 
            this._contextMenuDeleteKeys.Enabled = false;
            this._contextMenuDeleteKeys.Name = "_contextMenuDeleteKeys";
            this._contextMenuDeleteKeys.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this._contextMenuDeleteKeys.Size = new System.Drawing.Size(192, 22);
            this._contextMenuDeleteKeys.Text = "Delete keys";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolbarNewKey,
            this._toolbarEditKey,
            this.toolStripSeparator1,
            this._toobarDeleteKeys});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(969, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _toolbarNewKey
            // 
            this._toolbarNewKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarNewKey.Enabled = false;
            this._toolbarNewKey.Image = global::CloudKeysUI.Properties.Resources.Entry;
            this._toolbarNewKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarNewKey.Name = "_toolbarNewKey";
            this._toolbarNewKey.Size = new System.Drawing.Size(28, 28);
            this._toolbarNewKey.Text = "toolStripButton1";
            this._toolbarNewKey.Click += new System.EventHandler(this._toolbarNewKey_Click);
            // 
            // _toolbarEditKey
            // 
            this._toolbarEditKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolbarEditKey.Enabled = false;
            this._toolbarEditKey.Image = global::CloudKeysUI.Properties.Resources.Edit;
            this._toolbarEditKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolbarEditKey.Name = "_toolbarEditKey";
            this._toolbarEditKey.Size = new System.Drawing.Size(28, 28);
            this._toolbarEditKey.Text = "toolStripButton1";
            this._toolbarEditKey.Click += new System.EventHandler(this._toolbarEditKey_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // _toobarDeleteKeys
            // 
            this._toobarDeleteKeys.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toobarDeleteKeys.Enabled = false;
            this._toobarDeleteKeys.Image = global::CloudKeysUI.Properties.Resources.Delete;
            this._toobarDeleteKeys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toobarDeleteKeys.Name = "_toobarDeleteKeys";
            this._toobarDeleteKeys.Size = new System.Drawing.Size(28, 28);
            this._toobarDeleteKeys.Text = "toolStripButton1";
            this._toobarDeleteKeys.Click += new System.EventHandler(this._toobarDeleteKeys_Click);
            // 
            // KeyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._listview);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KeyList";
            this.Size = new System.Drawing.Size(969, 638);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _listview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton _toolbarNewKey;
        private System.Windows.Forms.ToolStripButton _toolbarEditKey;
        private System.Windows.Forms.ToolStripButton _toobarDeleteKeys;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _contextMenuCopyKeys;
        private System.Windows.Forms.ToolStripMenuItem _contextMenuPasteKeys;
        private System.Windows.Forms.ToolStripMenuItem _contextMenuDuplicateKeys;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _contextMenuNewKey;
        private System.Windows.Forms.ToolStripMenuItem _contextMenuEditKey;
        private System.Windows.Forms.ToolStripMenuItem _contextMenuDeleteKeys;
    }
}
