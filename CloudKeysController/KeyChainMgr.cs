using CloudKeysModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;

namespace CloudKeysController
{
    public class KeyChainMgr
    {
        private KeyChain _keyChain;

        public KeyChainMgr()
        {
            _keyChain = new KeyChain();
            Histories = new List<History>();
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
            string filename;
            if (_keyChain.Password == null || _keyChain.Password == "" || saveAs)
            {
                PasswordDialog pd = new PasswordDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    _keyChain.Password = pd.Password;
                }
                else
                {
                    return "";
                }
                
            }
            if (_keyChain.Filename == null || _keyChain.Filename == "" || _keyChain.Filename == KeyChain.DefaultFilename || saveAs)
            {
                SaveFileDialog d = new SaveFileDialog();
                string exe = Assembly.GetExecutingAssembly().Location;
                d.InitialDirectory = Path.GetDirectoryName(exe);
                d.RestoreDirectory = true;
                d.AddExtension = true;
                d.Filter = "KCF Documents (*.kcf)|*.kcf";
                if (d.ShowDialog() != DialogResult.OK)
                    return "";
                _keyChain.Filename = d.FileName;
            }
            filename = _keyChain.Filename;

            // Ask to set the password.
            // If the DialogResult == DialogResult.Cancel.
            // Show error message.
            // return ""; // Means no password is given, will not save file.

            MemoryStream ms = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(KeyChain));

            serializer.WriteObject(ms, _keyChain);
            byte[] plainBytes = new byte[ms.Length];
            Array.Copy(ms.GetBuffer(), plainBytes, plainBytes.Length);
            byte[] encryptedBytes = CryptoHelper.Encrypt(plainBytes);

            File.WriteAllBytes(filename, encryptedBytes);
            _keyChain.Saved = true;
            return filename;
        }

        public string Load()
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "KCF Documents (*.kcf)|*.kcf";
            if (d.ShowDialog() != DialogResult.OK)
                return "";
            string filename = d.FileName;
            string resFilename;
            while ((resFilename = Load(filename)) == KeyChain.WrongPassword)
            {

            }
            return resFilename;
        }

        public string Load(string filename)
        {
            _keyChain = new KeyChain();
            DataContractSerializer serializer = new DataContractSerializer(typeof(KeyChain));

            byte[] encryptedBytes = File.ReadAllBytes(filename);
            byte[] plainBytes = CryptoHelper.Decrypt(encryptedBytes);

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(plainBytes, 0, plainBytes.Length);
                ms.Position = 0;
                ms.Flush();

                StreamReader sr = new StreamReader(ms);
                string res = sr.ReadToEnd();
                Console.WriteLine(res);
                ms.Position = 0;

                KeyChain keychain = (KeyChain)serializer.ReadObject(ms);
                bool correctPassword = true;
                if (keychain.Password != null && keychain.Password != "")
                {
                    PasswordDialog pd = new PasswordDialog();
                    pd.Filename = filename;
                    pd.RealPassword = keychain.Password;
                    if (pd.ShowDialog() == DialogResult.Abort)
                    {
                        return KeyChain.WrongPassword;
                    }
                }
                if (correctPassword)
                {
                    _keyChain = keychain;
                    _keyChain.Filename = filename;
                    _keyChain.Saved = true;
                    int limit = PreferencesMgr.Preference.RecentFileLimit;
                    if (limit > PreferencesMgr.Preference.RecentFiles.Count)
                    {
                        PreferencesMgr.Preference.RecentFiles.Add(filename);
                    }
                    else
                    {
                        PreferencesMgr.Preference.RecentFiles.Add(filename);
                        PreferencesMgr.Preference.RecentFiles.RemoveAt(0);
                    }
                    PreferencesMgr.SaveFile();
                    return filename;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
