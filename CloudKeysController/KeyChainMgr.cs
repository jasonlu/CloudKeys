using CloudKeysModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using DropNet;
using DropNet.Models;
using System.Drawing;
using System.Drawing.Printing;


namespace CloudKeysController
{
    public class KeyChainMgr
    {
        // Save to dropbox here...
        private KeyChain _keyChain;
        private static string _foundKeysGroup = "[Found keys]";
        private Font _printFont;

        public KeyChainMgr()
        {
            _keyChain = new KeyChain();
            Histories = new List<History>();
            _printFont = PreferencesMgr.Preference.Font;
        }

        public KeyChain KeyChain
        {
            get { return _keyChain; }
            set { _keyChain = value; }
        }

        public List<Group> GetGroups()
        {
            return _keyChain.Groups;
        }

        public List<History> Histories { get; set; }

        public KeyChain NewKeyChain()
        {
            _keyChain = new KeyChain();
            _keyChain.Saved = true;
            return _keyChain;
        }

        private void newHistory(string text, CloudKeysModel.Action type)
        {
            History h = new History(this);
            h.Action = type;
            h.Description = text;
            h.Commit();
            Histories.Add(h);
        }

        public void AddGroup(Group g)
        {
            _keyChain.Groups.Add(g);
            _keyChain.CurrentGroup = g;
            _keyChain.Saved = false;
            newHistory("Add Group: " + g.Title, CloudKeysModel.Action.Create);
        }

        public void DeleteGroup(Group g)
        {
            int index = _keyChain.Groups.IndexOf(g);
            _keyChain.Groups.Remove(g);
            if (index >= _keyChain.Groups.Count)
            {
                _keyChain.CurrentGroup = null;
            }
            else
            {
                _keyChain.CurrentGroup = _keyChain.Groups[index];
            }
            _keyChain.Saved = false;
            newHistory("Delete Group: " + g.Title, CloudKeysModel.Action.Delete);
        }

        public void EditGroup(Group g)
        {
            //Group thisGroup = _keyChain.CurrentGroup;
            //int index = _keyChain.Groups.IndexOf(thisGroup);
            //_keyChain.Groups.Remove(thisGroup);
            //_keyChain.Groups.Insert(index, g);
            _keyChain.Saved = false;
            newHistory("Edit Group: " + g.Title, CloudKeysModel.Action.Update);
        }

        public void DeleteKey(Key k)
        {
            DialogResult res = MessageBox.Show("Are you sure to delete this key: \n " + k.Title + "\nThis opration cannot be undone.", "Think twice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                _keyChain.CurrentGroup.Keys.Remove(k);
                _keyChain.CurrentKey = null;
                _keyChain.CurrentKeys = null;
                _keyChain.Saved = false;
                newHistory("Delete Key: " + k.Title, CloudKeysModel.Action.Delete);
            }
        }

        public void DeleteKey(List<Key> keys)
        {
            DialogResult res = MessageBox.Show("Are you sure to delete " + keys.Count + " keys.\nThis opration cannot be undone.", "Think twice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                foreach (Key k in keys)
                {
                    _keyChain.CurrentGroup.Keys.Remove(k);
                }
                _keyChain.CurrentKey = null;
                _keyChain.CurrentKeys = null;
                _keyChain.Saved = false;
                newHistory("Delete " + keys.Count + " Keys: " + keys, CloudKeysModel.Action.Delete);
            }
        }

        public void AddKey(Key k)
        {
            _keyChain.CurrentGroup.Keys.Add(k);
            _keyChain.CurrentKey = k;
            _keyChain.CurrentKeys = new List<Key>();
            _keyChain.CurrentKeys.Add(k);
            _keyChain.Saved = false;
            newHistory("Add Key: " + k.Title, CloudKeysModel.Action.Create);
        }

        public void EditKey(Key k)
        {
            _keyChain.CurrentKey = k;
            _keyChain.CurrentKeys = new List<Key>();
            _keyChain.CurrentKeys.Add(k);
            _keyChain.Saved = false;
            newHistory("Edit Key: " + k.Title, CloudKeysModel.Action.Update);
        }



        public void Print()
        {
            _printFont = PreferencesMgr.Preference.Font;
            _printFont = new Font(_printFont.Name, 5);
            PrintDocument pd = new PrintDocument();
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            pd.PrintPage += new PrintPageEventHandler(OnPrintPage);
            ppd.Document = pd;
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            ppd.ShowDialog();

        }


        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            float linesPerPage = 0;
            float yPos = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float xPos = 0;
            float rowHeight = 0;
            float columnWidth = 0;

            rowHeight = _printFont.GetHeight(e.Graphics);
            columnWidth = (e.MarginBounds.Right - e.MarginBounds.Left) / 3;

            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height / _printFont.GetHeight(e.Graphics);
            int rows = 0;
            for (int i = 0; i < _keyChain.Groups.Count; i++)
            {
                Group g = _keyChain.Groups[i];
                yPos = topMargin + (rows * rowHeight);
                xPos = leftMargin;

                Pen pen = new Pen(Color.Gray);
                //e.Graphics.DrawRectangle(pen, xPos, yPos, columnWidth, rowHeight);

                e.Graphics.DrawString(g.Title, _printFont, Brushes.Black, xPos, yPos, new StringFormat());
                rows++;
                yPos = topMargin + (rows * rowHeight);
                e.Graphics.DrawLine(pen, xPos, yPos, e.MarginBounds.Right, yPos);

                foreach (Key k in g.Keys)
                {
                    yPos = topMargin + (rows * rowHeight);
                    yPos += 2;
                    xPos = leftMargin;

                    e.Graphics.DrawString(k.Title, _printFont, Brushes.Black, xPos, yPos, new StringFormat());

                    xPos = xPos + columnWidth;
                    e.Graphics.DrawLine(pen, xPos, yPos, xPos, yPos + rowHeight);

                    xPos += 2;
                    e.Graphics.DrawString(k.Username, _printFont, Brushes.Black, xPos, yPos, new StringFormat());

                    xPos = xPos + columnWidth;
                    e.Graphics.DrawLine(pen, xPos, yPos, xPos, yPos + rowHeight);

                    xPos += 2;
                    e.Graphics.DrawString(k.Password, _printFont, Brushes.Black, xPos, yPos, new StringFormat());
                    rows++;
                }
                rows++;
            }

            // If more lines exist, print another page. 
            //if (line != null)
            //e.HasMorePages = true;
            //else
            e.HasMorePages = false;
        }



        private Random _random = new Random((int)DateTime.Now.Ticks);

        public string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public string Save(bool saveAs = false)
        {
            if (_keyChain.Password == null || _keyChain.Password == "" || saveAs)
            {
                PasswordDialog pd = new PasswordDialog();
                pd.NewPassword = true;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    _keyChain.Password = pd.Password;
                }
                else
                {
                    return "";
                }
            }
            string exe = Assembly.GetExecutingAssembly().Location;
            string basename = "";
            string filePath = "";

            MemoryStream ms = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(KeyChain));
            serializer.WriteObject(ms, _keyChain);

            if (PreferencesMgr.Preference.SaveToCloud)
            {
                if (_keyChain.Filename == "" || _keyChain.Filename == KeyChain.DefaultFilename || saveAs)
                {
                    FilenameDialog fd = new FilenameDialog();
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        _keyChain.Filename = fd.Filename;
                    }
                    else
                    {
                        return "";
                    }
                }
                basename = DropboxMgr.WriteToCloud(_keyChain.Filename, ms.ToArray());
                basename = basename.Substring(basename.LastIndexOf("/") + 1);
                filePath = Path.GetDirectoryName(exe) + "\\" + basename;
            }
            else
            {
                if (_keyChain.Filename == "" || _keyChain.Filename == KeyChain.DefaultFilename || saveAs)
                {
                    SaveFileDialog d = new SaveFileDialog();

                    d.InitialDirectory = Path.GetDirectoryName(exe);
                    d.RestoreDirectory = true;
                    d.AddExtension = true;
                    d.Filter = "KCF Documents (*.kcf)|*.kcf";
                    if (d.ShowDialog() != DialogResult.OK)
                        return "";
                    _keyChain.Filename = d.FileName;
                    basename = d.FileName.Substring(d.FileName.LastIndexOf("\\") + 1);
                    filePath = d.FileName;
                }
                else
                {

                }

            }

            byte[] cipherBytes = CryptoHelper.Encrypt(ms.ToArray());
            File.WriteAllBytes(filePath, cipherBytes);
            _keyChain.Saved = true;
            return _keyChain.Filename;
        }

        public string Open(string path)
        {
            byte[] data;
            if (path.StartsWith("dropbox://"))
            {
                string url = path.Substring(path.LastIndexOf("://") + 3);
                data = DropboxMgr.ReadFileFromCloud(url);
            }
            else
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "KCF Documents (*.kcf)|*.kcf";
                if (d.ShowDialog() != DialogResult.OK)
                    return "";
                data = File.ReadAllBytes(d.FileName);
            }

            DataContractSerializer serializer = new DataContractSerializer(typeof(KeyChain));
            MemoryStream ms = new MemoryStream(data);
            KeyChain keychain = (KeyChain)serializer.ReadObject(ms);
            if (keychain.Password != null && keychain.Password != "")
            {
                PasswordDialog pd = new PasswordDialog();
                pd.Filename = path;
                pd.RealPassword = keychain.Password;
                if (pd.ShowDialog() == DialogResult.Abort)
                {
                    return KeyChain.WrongPassword;
                }
            }
            _keyChain = keychain;
            _keyChain.Filename = path;
            _keyChain.Saved = true;
            int limit = PreferencesMgr.Preference.RecentFileLimit;
            if (!PreferencesMgr.Preference.RecentFiles.Contains(path))
            {
                if (limit > PreferencesMgr.Preference.RecentFiles.Count)
                {
                    PreferencesMgr.Preference.RecentFiles.Add(path);
                }
                else
                {
                    PreferencesMgr.Preference.RecentFiles.Add(path);
                    PreferencesMgr.Preference.RecentFiles.RemoveAt(0);
                }
            }
            PreferencesMgr.SaveFile();
            return path;
        }

        public List<Key> SearchKey(string keyword, bool useTempGroup = false)
        {
            keyword = keyword.ToLower();
            List<Key> keys = new List<Key>();
            foreach (Group g in _keyChain.Groups)
            {
                foreach (Key k in g.Keys)
                {
                    if (k.Title.ToLower().Contains(keyword) ||
                        k.Username.ToLower().Contains(keyword) ||
                        k.URL.ToLower().Contains(keyword) ||
                        k.Notes.ToLower().Contains(keyword) ||
                        k.Password.ToLower().Contains(keyword))
                    {
                        keys.Add(k);
                    }
                }
            }
            if (useTempGroup)
            {
                Group newg = new Group();
                newg.Keys = keys;
                newg.Color = Color.Red;
                newg.Title = _foundKeysGroup;
                _keyChain.Groups.Add(newg);
            }
            return keys;
        }
    }
}
