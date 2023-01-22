using System.Collections;
using System.Reflection;

namespace AngbandOS.Core
{
    [Serializable]
    internal class SingletonFactory<T> : IEnumerable<T>
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

        public WeightedRandom<T> WeightedRandom(Func<T, bool> predicate) => new WeightedRandom<T>(this, predicate);

        public U Get<U>() where U:T
        {
            return (U)dictionary[typeof(U).Name];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public SingletonFactory(SaveGame saveGame)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load Commands.
                if (!type.IsAbstract && typeof(T).IsAssignableFrom(type))
                {
                    ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                    T command = (T)constructors[0].Invoke(new object[] { saveGame });
                    list.Add(command);
                    dictionary.Add(type.Name, command);
                }
            }
        }

        public SingletonFactory(SaveGame saveGame, T[] items)
        {
            foreach (T item in items)
            {
                list.Add(item);
                dictionary.Add(item.GetType().Name, item);
            }
        }
    }
}
