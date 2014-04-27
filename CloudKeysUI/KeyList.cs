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
            _listview.LostFocus += OnListviewLostFocus;

        }

        void OnListviewLostFocus(object sender, EventArgs e)
        {
            /*
            _mgr.KeyChain.CurrentKeys = null;
            _mgr.KeyChain.CurrentKey = null;
             */
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

        public void LoadKeys(List<Key> keys)
        {
            _listview.Items.Clear();
            foreach (Key k in keys)
            {
                ListViewItem item = new ListViewItem(new string[] { k.Title, k.URL, k.Username, k.Password });
                item.Tag = k;
                _listview.Items.Add(item);
            }
            _mgr.KeyChain.CurrentKey = null;
        }

        public void OpenKeyDialog(Key k = null)
        {
            KeyDialog kd = new KeyDialog(_mainForm);
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
                    _mgr.EditKey(returnedKey);
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
                _contextMenuCopyKeys.Enabled =
                _contextMenuDeleteKeys.Enabled =
                _contextMenuDuplicateKeys.Enabled =
                _contextMenuNewKey.Enabled =
                _toobarDeleteKeys.Enabled =
                _toolbarEditKey.Enabled = false;
            }
            else
            {
                _contextMenuCopyKeys.Enabled =
                _contextMenuDeleteKeys.Enabled =
                _contextMenuDuplicateKeys.Enabled =
                _contextMenuCopyKeys.Enabled =
                _contextMenuNewKey.Enabled =
                _toobarDeleteKeys.Enabled =
                _toolbarEditKey.Enabled = true;
            }
            _listview.Font = PreferencesMgr.Preference.Font;
        }

        #region Toolbar Event Handlers
        private void OnKeyNew(object sender, EventArgs e)
        {
            OpenKeyDialog();
            _listview.Select();
        }

        private void OnKeyEdit(object sender, EventArgs e)
        {
            Key k = (Key)_listview.SelectedItems[0].Tag;
            OpenKeyDialog(k);
            _listview.Select();
        }

        private void OnKeyDelete(object sender, EventArgs e)
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

        private void OnFind(object sender, EventArgs e)
        {
            string keyword = _txtKeyword.Text;
            List<Key> foundKeys = new List<Key>();
            foundKeys = _mgr.SearchKey(keyword);
            //_mainForm.GroupsTree.LoadGroups();
            _mgr.KeyChain.CurrentGroup = null;
            LoadKeys(foundKeys);
        }

        private void OnTxtKeywordKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                OnFind(sender, e);
            }
        }
        #endregion

        private void OnListviewItemActivate(object sender, EventArgs e)
        {
            ListView _lv = ((ListView)sender);
            Key k = (Key)_lv.SelectedItems[0].Tag;
            List<Key> keys = new List<Key>();
            keys.Add(k);
            _mgr.KeyChain.CurrentKey = k;
            _mgr.KeyChain.CurrentKeys = keys;
            OpenKeyDialog(k);
        }

        private void OnListviewItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            List<Key> keys = new List<Key>();
            foreach (ListViewItem i in _listview.SelectedItems)
            {
                keys.Add((Key)i.Tag);
            }
            if (keys.Count == 0)
            {
                _mgr.KeyChain.CurrentKey = null;
                _mgr.KeyChain.CurrentKeys = null;
            }
            else
            {
                _mgr.KeyChain.CurrentKeys = keys;
            }
            if (e.IsSelected)
            {
                Key k = (Key)e.Item.Tag;
                _mgr.KeyChain.CurrentKey = k;
                _mainForm.UpdateDetail(k);
            }
            else
            {
                _mgr.KeyChain.CurrentKeys = null;
            }
        }

        private void OnListviewColumnClick(object sender, ColumnClickEventArgs e)
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
            _mgr.KeyChain.CurrentKey = null;
            _mgr.KeyChain.CurrentKeys = null;
        }
        #endregion

        private void OnKeyCopy(object sender, EventArgs e)
        {
            List<Key> keys = new List<Key>();

            for (int i = 0; i < _listview.SelectedItems.Count; i++)
            {
                keys.Add((Key)_listview.SelectedItems[i].Tag);
            }

            //Lets say its my data format
            string format = "KeyChainKeys";
            Clipboard.Clear();
            //Set data to clipboard
            Clipboard.SetData(format, keys);
            _contextMenuPasteKeys.Enabled = true;
        }

        private void OnKeyPaste(object sender, EventArgs e)
        {
            Group g = _mgr.KeyChain.CurrentGroup;
            if (g == null)
            {
                MessageBox.Show("Plase select a group");
                return;
            }
            //Get data from clipboard
            List<Key> keys = new List<Key>();
            string format = "KeyChainKeys";
            if (Clipboard.ContainsData(format))
            {
                keys = (List<Key>)Clipboard.GetData(format);
            }
            if (keys == null)
            {
                MessageBox.Show("No Keys in Clipboard.");
                return;
            }
            foreach (Key k in keys)
            {
                //Key key = new Key();
                _mgr.AddKey(k.Clone());
            }
            LoadKeys();
            _mgr.KeyChain.CurrentKey = keys.Last();
            _mgr.KeyChain.CurrentKeys = keys;
        }

        private void OnKeyDuplicate(object sender, EventArgs e)
        {
            Key thisKey = _mgr.KeyChain.CurrentKey;
            if (thisKey == null)
            {
                return;
            }
            Key k = thisKey.Clone();
            List<Key> keys = new List<Key>();
            _mgr.AddKey(k);
            LoadKeys();

            _mgr.KeyChain.CurrentKey = k;
            _mgr.KeyChain.CurrentKeys = keys;
        }

        internal void ClearKeys()
        {
            _listview.Items.Clear();
        }
    }
}
