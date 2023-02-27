using System.Collections;

namespace AngbandOS.Core
{
    [Serializable]
    internal class SingletonDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
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

        public SingletonDictionary(SaveGame saveGame, TValue[] items, Func<TValue, TKey> keyRetrieval)
        {
            foreach (TValue item in items)
            {
                TKey key = keyRetrieval(item);
                instances.Add(key, item);
            }
        }

        public SingletonDictionary(SaveGame saveGame, Dictionary<TKey, TValue> dictionary)
        {
            instances = dictionary;
        }
    }
}
