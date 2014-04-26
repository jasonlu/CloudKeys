using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudKeysController;
using CloudKeysModel;

namespace CloudKeysUI
{
    public partial class KeyList : UserControl
    {

        private ListViewColumnSorter _sorter;


        private MainForm _mainForm;

        public MainForm MainForm
        {
            get { return _mainForm; }
            set { _mainForm = value; }
        }
        

        private KeyChainMgr _mgr;

        public KeyChainMgr KeyChainMgr
        {
            get { return _mgr; }
            set { _mgr = value; }
        }

        public KeyList()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
            _mgr = new KeyChainMgr();
            _sorter = new ListViewColumnSorter();
            _listview.ListViewItemSorter = _sorter;
  
        }

        public void LoadKeys()
        {
            _listview.Items.Clear();
            if (_mgr.KeyChain.CurrentGroup == null)
            {
                return;
            }
            List<Key> keys = _mgr.KeyChain.CurrentGroup.Keys;
            foreach (Key k in keys)
            {
                ListViewItem item = new ListViewItem(new string[] { k.Title, k.URL, k.Username, k.Password });
                item.Tag = k;
                _listview.Items.Add(item);
            }
            _mgr.KeyChain.CurrentKey = null;
        }

        public void ShowKeyDialog(Key k = null)
        {
            KeyDialog kd = new KeyDialog();
            kd.Key = k;
            if (kd.ShowDialog() == DialogResult.OK)
            {
                Key returnedKey = kd.Key;
                if (k == null)
                {
                    _mgr.AddKey(returnedKey);
                }
                else
                {
                    Group g = _mgr.KeyChain.CurrentGroup;
                    int index = g.Keys.IndexOf(k);
                    g.Keys.Remove(k);
                    g.Keys.Insert(index, returnedKey);
                    _mgr.EditKey(k);
                }
                LoadKeys();
                _mgr.KeyChain.CurrentKey = returnedKey;
                _mgr.KeyChain.Saved = false;
            }
        }

        #region Event Handlers
        void Application_Idle(object sender, EventArgs e)
        {
            if (_mgr.KeyChain.CurrentGroup == null)
            {
                _toolbarNewKey.Enabled = false;
            }
            else
            {
                _toolbarNewKey.Enabled = true;
            }
            if (_listview.SelectedItems.Count == 0)
            {
                _toobarDeleteKeys.Enabled = _toolbarEditKey.Enabled = false;
            }
            else
            {
                _toobarDeleteKeys.Enabled = _toolbarEditKey.Enabled = true;
            }
            _listview.Font = PreferencesMgr.Preference.Font;
        }

        #region Toolbar Event Handlers
        private void _toolbarNewKey_Click(object sender, EventArgs e)
        {
            ShowKeyDialog();
            _listview.Select();
        }

        private void _toolbarEditKey_Click(object sender, EventArgs e)
        {
            Key k = (Key)_listview.SelectedItems[0].Tag;
            ShowKeyDialog(k);
            _listview.Select();
        }

        private void _toobarDeleteKeys_Click(object sender, EventArgs e)
        {
            if (_listview.SelectedItems.Count > 1)
            {
                List<Key> keys = new List<Key>();
                foreach (ListViewItem i in _listview.SelectedItems)
                {
                    keys.Add((Key)i.Tag);
                }
                _mgr.DeleteKey(keys);

            }
            else
            {
                Key k = (Key)_listview.SelectedItems[0].Tag;
                _mgr.DeleteKey(k);
            }
            
            LoadKeys();
        }
        #endregion

        private void _listview_ItemActivate(object sender, EventArgs e)
        {
            ListView _lv = ((ListView)sender);
            Key k = (Key)_lv.SelectedItems[0].Tag;
            ShowKeyDialog(k);
        }

        private void _listview_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
          
        }
       

        private void _listview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            List<Key> keys = new List<Key>();
            foreach (ListViewItem i in _listview.SelectedItems)
            {
                keys.Add((Key)i.Tag);
            }

            _mgr.KeyChain.CurrentKeys = keys;
            if(e.IsSelected)
            {
                Key k = (Key)e.Item.Tag;
                _mgr.KeyChain.CurrentKey = k;
                _mainForm.UpdateDetail(k);
            }
        }

        private void _listview_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _sorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_sorter.Order == SortOrder.Ascending)
                {
                    _sorter.Order = SortOrder.Descending;
                }
                else
                {
                    _sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _sorter.SortColumn = e.Column;
                _sorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            _listview.Sort();
        }

      
        #endregion

        
    }
}
