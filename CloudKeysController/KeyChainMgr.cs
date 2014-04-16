using CloudKeysModel;
using System.Collections.Generic;

namespace CloudKeysController
{
    public class KeyChainMgr
    {
        public KeyChain KeyChain;
        public List<Group> getGroups()
        {
            return KeyChain.Groups;
        }

    }
}
