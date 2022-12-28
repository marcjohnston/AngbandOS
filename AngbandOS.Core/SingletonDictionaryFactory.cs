using System.Collections;

namespace AngbandOS.Core
{
    [Serializable]
    internal class SingletonDictionaryFactory<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
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

        public SingletonDictionaryFactory(SaveGame saveGame, Dictionary<TKey, TValue> dictionary)
        {
            instances = dictionary;
        }
    }
}
