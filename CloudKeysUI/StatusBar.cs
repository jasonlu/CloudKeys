using System;
using System.Windows.Forms;

namespace CloudKeysUI
{
    public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();
            _clockTicker.Start();
            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {

        }

        private void _clockTicker_Tick(object sender, EventArgs e)
        {
            _currentTime.Text = DateTime.Now.ToString();
        }
    }
}
