namespace CloudKeysUI
{
    partial class PreferencesForm
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
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _propertyGrid
            // 
            this._propertyGrid.HelpVisible = false;
            this._propertyGrid.Location = new System.Drawing.Point(12, 12);
            this._propertyGrid.Name = "_propertyGrid";
            this._propertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this._propertyGrid.Size = new System.Drawing.Size(389, 206);
            this._propertyGrid.TabIndex = 0;
            this._propertyGrid.ToolbarVisible = false;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(245, 224);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(326, 224);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 2;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // PreferencesForm
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(413, 251);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._propertyGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.ShowInTaskbar = false;
            this.Text = "Preferences";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid _propertyGrid;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
    }
}