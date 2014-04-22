using System;
using System.Windows.Forms;
using CloudKeysModel;
using System.Collections.Generic;

namespace CloudKeysUI
{
    public partial class StatusBar : UserControl
    {
        private int _groupCount = 0;
        private int _keyCount = 0;
        Group _currentGroup = null;
        List<Key> _currentKeys = new List<Key>();


        public int GroupCount
        {
            get { return _groupCount; }
            set { _groupCount = value; }
        }

        private MainForm _mainForm;

        public MainForm MainForm
        {
            get { return _mainForm; }
            set { _mainForm = value; }
        }

        private CloudKeysController.KeyChainMgr _mgr;

        public CloudKeysController.KeyChainMgr KeyChainMgr
        {
            get { return _mgr; }
            set { _mgr = value; }
        }

        public StatusBar()
        {
            InitializeComponent();
            _clockTicker.Start();
            Application.Idle += Application_Idle;

        }

        public void UpdateStatus()
        {
            if (_groupCount != _mgr.KeyChain.Groups.Count)
            {
                _groupCount = _mgr.KeyChain.Groups.Count;
                _totalGroups.Text = _groupCount + " Groups";
            }
            if (_mgr.KeyChain.CurrentGroup == null)
            {
                return;
            }
            else
            {
                if (_keyCount != _mgr.KeyChain.CurrentGroup.Keys.Count)
                {
                    _keyCount = _mgr.KeyChain.CurrentGroup.Keys.Count;
                    _selectedKeys.Text = _currentKeys.Count + " Of " + _keyCount + " Selected";
                }

                if (_currentKeys != _mgr.KeyChain.CurrentKeys && _mgr.KeyChain.CurrentKeys != null)
                {
                    _currentKeys = _mgr.KeyChain.CurrentKeys;
                    _selectedKeys.Text = _currentKeys.Count + " Of " + _keyCount + " Selected";
                }
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void _clockTicker_Tick(object sender, EventArgs e)
        {
            _currentTime.Text = DateTime.Now.ToString();
        }
    }
}
