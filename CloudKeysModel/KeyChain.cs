using System.Collections.Generic;

namespace CloudKeysModel
{
    public class KeyChain
    {
        List<Group> _groups;
        Group _currentGroup;
        Key _currentKey;
        string _filename;
        bool _saved;
        public const string DefaultFilename = "?\\NEWFILE\\?";

        public KeyChain()
        {
            _groups = new List<Group>();
            _filename = DefaultFilename;// "?\\NEWFILE\\?";
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
