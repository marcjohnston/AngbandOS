using System.Collections;

namespace AngbandOS.Core
{
    [Serializable]
    internal class SingletonDictionary<T> : SingletonList<T>, IEnumerable<T> // TODO: This is a SingletonDictionary ... using GetType().Name as the KeyRetrieval
    {
        Dictionary<string, T> dictionary = new Dictionary<string, T>();

        public bool Contains(T item) => dictionary.ContainsKey(item.GetType().Name);

        public U Get<U>() where U : T
        {
            return (U)dictionary[typeof(U).Name];
        }

        public T Get(string typename)
        {
            return dictionary[typename];
        }

        /// <summary>
        /// Adds an item to the repository.  This is often used to add configured objects.
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item) 
        {
            base.Add(item);
            dictionary.Add(item.GetType().Name, item);
        }

        public SingletonDictionary(SaveGame saveGame, params T[] items) : base(saveGame, items)
        {
        }

        public SingletonDictionary(SaveGame saveGame, IEnumerable<T> items) : base(saveGame, items)
        {
        }
    }

    //[Serializable]
    //internal class SingletonDualDictionary<T, U>
    //{
    //    Dictionary<string, Dictionary<string, T>> dictionary = new Dictionary<string, Dictionary<string, T>>();

    //    public bool Contains(T item) => dictionary.ContainsKey(item.GetType().Name);

    //    public U Get<U>() where U : T
    //    {
    //        return (U)dictionary[typeof(U).Name];
    //    }

    //    public T Get(string typename)
    //    {
    //        return dictionary[typename];
    //    }

    //    /// <summary>
    //    /// Adds an item to the repository.  This is often used to add configured objects.
    //    /// </summary>
    //    /// <param name="item"></param>
    //    public override void Add(T item)
    //    {
    //        base.Add(item);
    //        dictionary.Add(item.GetType().Name, item);
    //    }

    //    public SingletonDictionary(SaveGame saveGame, params T[] items) : base(saveGame, items)
    //    {
    //    }

    //    public SingletonDictionary(SaveGame saveGame, IEnumerable<T> items) : base(saveGame, items)
    //    {
    //    }
    //}
}
