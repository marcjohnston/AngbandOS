using System;

namespace Cthangband.PersistentStorage
{
    [Serializable]
    internal class SqlPersistentStorage : IPersistentStorage
    {
        public string Read(string slot)
        {
            return null;
        }

        public bool Write(string value, string filename)
        {
            return true;
        }
    }
}
