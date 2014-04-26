using CloudKeysController;
using CloudKeysModel;
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
    public partial class PreferencesForm : Form
    {
        Preference _preference = new Preference();

        public PreferencesForm()
        {
            InitializeComponent();
            this.Shown += PreferencesForm_Shown;
            _propertyGrid.SelectedObject = _preference;
        }

        void PreferencesForm_Shown(object sender, EventArgs e)
        {
            _preference = PreferencesMgr.Preference;
            _propertyGrid.SelectedObject = _preference;
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            PreferencesMgr.Preference = _preference;
            PreferencesMgr.SaveFile();
            DialogResult = DialogResult.OK;
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
           
        }

        
    }
}
