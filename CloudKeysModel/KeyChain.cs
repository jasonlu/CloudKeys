using System.Collections.Generic;

namespace CloudKeysModel
{
    public class KeyChain
    {
        List<Group> _groups;
        Group _currentGroup;
        Key _currentKey;
        private List<Key> _currentKeys;

        public List<Key> CurrentKeys
        {
            get { return _currentKeys; }
            set { _currentKeys = value; }
        }

        string _filename;
        string _fullpath;
        bool _saved;
        public const string DefaultFilename = "?\\NEWFILE\\?";
        public const string WrongPassword = "?\\WRONGPASSWORD\\?";

        public KeyChain()
        {
            _groups = new List<Group>();
            _filename = DefaultFilename;// "?\\NEWFILE\\?";
            _currentGroup = null;
            _currentKey = null;
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public List<Group> Groups
        {
            get { return _groups; }
        }

        public Group CurrentGroup
        {
            set { _currentGroup = value; }
            get { return _currentGroup; }
        }

        public Key CurrentKey
        {
            set { _currentKey = value; }
            get { return _currentKey; }
        }

        public string Filename
        {
            set { _filename = value; }
            get { return _filename; }
        }

        public bool Saved
        {
            set { _saved = value; }
            get { return _saved; }
        }
    }
}
