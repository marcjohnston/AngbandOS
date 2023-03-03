using System.Collections;

namespace AngbandOS.Core
{
    [Serializable]
    internal class SingletonDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private SaveGame SaveGame;
        private Func<TValue, TKey> _keyRetrieval;
        Dictionary<TKey, TValue> instances = new Dictionary<TKey, TValue>();
        public int Count => instances.Count;
        public TValue this[TKey index]
        {
            get
            {
                return instances[index];
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return instances.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return instances.GetEnumerator();
        }

        public void Add(TValue item)
        {
            TKey key = _keyRetrieval(item);
            instances.Add(key, item);
        }

        public SingletonDictionary(SaveGame saveGame, TValue[] items, Func<TValue, TKey> keyRetrieval)
        {
            SaveGame = saveGame;
            _keyRetrieval = keyRetrieval;
            foreach (TValue item in items)
            {
                Add(item);
            }
        }

        public SingletonDictionary(SaveGame saveGame, Dictionary<TKey, TValue> dictionary)
        {
            instances = dictionary;
        }
    }
}
