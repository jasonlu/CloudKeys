using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudKeysController
{
    public partial class FilenameDialog : Form
    {
        private string _filename = "";

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        public FilenameDialog()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _lblDescription.Text = "Filename:";
        }

        private void OnOK(object sender, EventArgs e)
        {
            _filename = _txtFilename.Text;
            DialogResult = DialogResult.OK;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (_filename != "")
            {
                _txtFilename.Text = _filename;
                _txtFilename.SelectAll();
            }
            _txtFilename.Focus();
        }
    }
}
