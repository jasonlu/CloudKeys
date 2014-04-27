using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudKeysModel;
using CloudKeysController;

namespace CloudKeysUI
{
    public partial class GroupDialog : Form
    {
        Group _group;
        KeyChainMgr _mgr = new KeyChainMgr();

        public Group Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public GroupDialog()
        {
            InitializeComponent();
            Application.Idle += OnIdle;
            _colorPicker.DropDownStyle = ComboBoxStyle.DropDownList;
            _colorPicker.MouseDown += OnColorPickerMouseDown;
            LoadColors();
        }

        void OnColorPickerMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ColorDialog cd = new ColorDialog();
                DialogResult r = cd.ShowDialog();
                if (r == DialogResult.OK)
                {
                    int index = 0;
                    Color c = cd.Color;
                    index = _colorPicker.Items.IndexOf("OTHER");
                    if (index == -1)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Text = "OTHER";
                        item.Value = c.ToArgb();
                        _colorPicker.Items.Insert(0, item);
                        index = 0;

                    }
                    _colorPicker.SelectedItem = _colorPicker.Items[index];

                    //c.Name
                    //                    _colorPicker.Select(index, 1);
                }

            }

        }


        private void LoadColors()
        {
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {

                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = prop.Name;
                    item.Value = (Color.FromName(prop.Name)).ToArgb();
                    _colorPicker.Items.Add(item);
                }
                _colorPicker.SelectedItem = _colorPicker.Items[0];
            }
        }

        void OnIdle(object sender, EventArgs e)
        {
            if (_textboxGroupName.Text == "")
                _btnOk.Enabled = false;
            else
                _btnOk.Enabled = true;
        }

        private void OnOK(object sender, EventArgs e)
        {
            _group.Title = _textboxGroupName.Text;
            if (_colorPicker.SelectedItem != null)
            {
                int colorName = ((ComboBoxItem)_colorPicker.SelectedItem).Value;
                _group.Color = Color.FromArgb(colorName);
            }
            else
            {
                _group.Color = Color.Black;
            }
            this.Tag = _group;
            DialogResult = DialogResult.OK;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (_group == null)
            {
                _group = new Group();
            }
            _textboxGroupName.Text = _group.Title;
            int colorArgbValue = _group.Color.ToArgb();
            int index = 0;
            foreach (ComboBoxItem i in _colorPicker.Items)
            {
                if (i.Value == colorArgbValue)
                {
                    index = _colorPicker.Items.IndexOf(i);
                    break;
                }
            }
            _colorPicker.SelectedIndex = index;
        }

        private void OnTest(object sender, EventArgs e)
        {
            _textboxGroupName.Text = _mgr.RandomString(10);
            Random ran = new Random((int)DateTime.Now.Ticks);
            int randomIndex = ran.Next(_colorPicker.Items.Count);
            _colorPicker.SelectedIndex = randomIndex;
        }
    }
}


public class ComboBoxItem
{
    public string Text { get; set; }
    public int Value { get; set; }

    public override string ToString()
    {
        return Text;
    }
}