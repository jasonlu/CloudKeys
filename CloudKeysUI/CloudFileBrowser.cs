using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudKeysUI
{
    public partial class CloudFileBrowser : Form
    {
        public CloudFileBrowser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            //this._listbox
            this.Load += OnLoad;
            this._listbox.DoubleClick += OnListBoxDoubleClick;
            this._btnOK.Click += OnOk;
        }

        private void OnListBoxDoubleClick(object sender, EventArgs e)
        {
            OnOk(sender, e);
        }

        private void OnOk(object sender, EventArgs e)
        {
            if (_listbox.SelectedItem == null)
            {
                return;
            }
            _filename = _listbox.SelectedItem.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

       
        private void OnLoad(object sender, EventArgs e)
        {
            _listbox.Items.Clear();
            foreach (string f in _files)
            {
                _listbox.Items.Add(f);
            }
        }

        private List<string> _files;

        public List<string> Files
        {
            get { return _files; }
            set { _files = value; }
        }

        private string _filename;

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        
    }
}
