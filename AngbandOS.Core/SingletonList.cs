using System.Collections;
using System.Reflection;

namespace AngbandOS.Core
{
    [Serializable]
    internal class SingletonList<T> : IEnumerable<T>
    {
        List<T> list = new List<T>();
        Dictionary<string, T> dictionary = new Dictionary<string, T>();

        public T this[int index]
        {
            get {
                return list[index];
            }
        }

        public int Count => list.Count;

        public WeightedRandom<T> WeightedRandom(Func<T, bool>? predicate = null) => new WeightedRandom<T>(this, predicate);

        public U Get<U>() where U:T
        {
            return (U)dictionary[typeof(U).Name];
        }

        public T Get(string typename)
        {
            return dictionary[typename];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the repository.  This is often used to add configured objects.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            list.Add(item);
            dictionary.Add(item.GetType().Name, item);
        }

        public SingletonList(SaveGame saveGame, IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }
    }
}
