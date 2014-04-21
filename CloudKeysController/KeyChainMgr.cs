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

        public void AddGroup(Group g)
        {
            _keyChain.Groups.Add(g);
            _keyChain.CurrentGroup = g;
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
        }

        public void EditGroup(Group g)
        {
            //_keyChain.Groups
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
            if (_keyChain.Filename == null || saveAs)
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
            return Load(filename);
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
                _keyChain = keychain;
                _keyChain.Filename = filename;
                _keyChain.Saved = true;
                return filename;
            }
        }
    }
}
