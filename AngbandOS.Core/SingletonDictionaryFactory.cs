using System.Collections;

namespace AngbandOS.Core
{
    [Serializable]
    internal class SingletonDictionaryFactory<S, T> : IEnumerable<KeyValuePair<S, T>>
    {
        Dictionary<S, T> instances = new Dictionary<S, T>();
        public int Count => instances.Count;
        public T this[S index]
        {
            get
            {
                return instances[index];
            }
        }

        public IEnumerator<KeyValuePair<S, T>> GetEnumerator()
        {
            return instances.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return instances.GetEnumerator();
        }

        public SingletonDictionaryFactory(SaveGame saveGame, Dictionary<S, T> dictionary)
        {
            instances = dictionary;
        }
    }
}
