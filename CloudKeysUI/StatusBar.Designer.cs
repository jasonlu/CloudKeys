﻿namespace CloudKeysUI
{
    partial class StatusBar
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._historyBox = new System.Windows.Forms.ComboBox();
            this._totalGroups = new System.Windows.Forms.Label();
            this._selectedKeys = new System.Windows.Forms.Label();
            this._currentTime = new System.Windows.Forms.Label();
            this._clockTicker = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this._historyBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._totalGroups, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._selectedKeys, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this._currentTime, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2024, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _historyBox
            // 
            this._historyBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._historyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._historyBox.FormattingEnabled = true;
            this._historyBox.Location = new System.Drawing.Point(4, 5);
            this._historyBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._historyBox.Name = "_historyBox";
            this._historyBox.Size = new System.Drawing.Size(1416, 28);
            this._historyBox.TabIndex = 0;
            // 
            // _totalGroups
            // 
            this._totalGroups.AutoSize = true;
            this._totalGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this._totalGroups.Location = new System.Drawing.Point(1428, 0);
            this._totalGroups.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._totalGroups.Name = "_totalGroups";
            this._totalGroups.Size = new System.Drawing.Size(142, 42);
            this._totalGroups.TabIndex = 1;
            this._totalGroups.Text = "0 Groups";
            this._totalGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _selectedKeys
            // 
            this._selectedKeys.AutoSize = true;
            this._selectedKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this._selectedKeys.Location = new System.Drawing.Point(1578, 0);
            this._selectedKeys.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._selectedKeys.Name = "_selectedKeys";
            this._selectedKeys.Size = new System.Drawing.Size(142, 42);
            this._selectedKeys.TabIndex = 2;
            this._selectedKeys.Text = "0 of 0 selected";
            this._selectedKeys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _currentTime
            // 
            this._currentTime.AutoSize = true;
            this._currentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this._currentTime.Location = new System.Drawing.Point(1728, 0);
            this._currentTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._currentTime.Name = "_currentTime";
            this._currentTime.Size = new System.Drawing.Size(292, 42);
            this._currentTime.TabIndex = 3;
            this._currentTime.Text = "00:00:00";
            this._currentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _clockTicker
            // 
            this._clockTicker.Interval = 1000;
            this._clockTicker.Tick += new System.EventHandler(this._clockTicker_Tick);
            // 
            // StatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StatusBar";
            this.Size = new System.Drawing.Size(2024, 42);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox _historyBox;
        private System.Windows.Forms.Label _totalGroups;
        private System.Windows.Forms.Label _selectedKeys;
        private System.Windows.Forms.Label _currentTime;
        private System.Windows.Forms.Timer _clockTicker;
    }
}
