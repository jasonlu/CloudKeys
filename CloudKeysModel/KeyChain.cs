using System.Collections.Generic;

namespace CloudKeysModel
{
    class KeyChain
    {
        List<Group> _groups;
        Group _currentGroup;
        Key _currentKey;
        string _filename;
        bool _saved;

        List<Group> Groups
        {
            get { return _groups; }
        }

        Group CurrentGroup
        {
            get { return _currentGroup; }
        }

        Key CurrentKey
        {
            get { return _currentKey; }
        }

        string Filename
        {
            get { return _filename; }
        }

        bool Saved
        {
            get { return _saved; }
        }
    }
}
