// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections.Generic;

namespace AngbandOS.Core.RepositoryCollections;

/// <summary>
/// Represents a RepositoryCollection that uses a Dictionary<> object to quickly retrieve objects from the repository by its' Type.
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
internal abstract class DictionaryRepositoryCollection<T> : ListRepositoryCollection<T> where T : IConfigurationItem
{
    Dictionary<string, T> dictionary = new Dictionary<string, T>();

    protected DictionaryRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    public bool Contains(T item) => dictionary.ContainsKey(item.GetType().Name);

    public U Get<U>() where U : T
    {
        return (U)dictionary[typeof(U).Name];
    }

    public T Get(string typename)
    {
        return dictionary[typename];
    }

    public T? TryGet(string typename)
    {
        if (!dictionary.ContainsKey(typename))
        {
            return default;
        }
        else
        {
            return dictionary[typename];
        }
    }

    /// <summary>
    /// Adds an item to the repository.  This is often used to add configured objects.
    /// </summary>
    /// <param name="item"></param>
    public override void Add(T item)
    {
        // We need to add this item to the underlying list so that the collection can be processed as an IEnumerable.
        base.Add(item);

        // Now we need to add it to the dictionary for fast lookup.
        string key = item.GetType().Name;
        dictionary.Add(key, item);
    }

    public override void Load()
    {
        Add(LoadTypesFromAssembly<T>());
    }


    public override void Loaded()
    {
        foreach (T item in this)
        {
            item.Loaded();
        }
    }
}
