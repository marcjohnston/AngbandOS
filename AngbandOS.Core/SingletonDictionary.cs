using System.Collections;

namespace AngbandOS.Core
{
    [Serializable]
    internal class SingletonDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> where TValue : ISingletonDictionary<TKey>
    {
        private SaveGame SaveGame;
        Dictionary<TKey, TValue> instances = new Dictionary<TKey, TValue>();
        public int Count => instances.Count;
        public TValue this[TKey index]
        {
            get
            {
                return instances[index];
            }
        }

        public bool Contains(TValue item) => instances.ContainsKey(item.GetKey);

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
            TKey key = item.GetKey;
            instances.Add(key, item);
        }

        public SingletonDictionary(SaveGame saveGame, TValue[] items)
        {
            SaveGame = saveGame;
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
