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
    }
}
