// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal abstract class DictionaryRepositoryCollection<TKey, TValue> : ListRepositoryCollection<TValue> where TValue : IGetKey<TKey> where TKey : notnull
{
    private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
    protected DictionaryRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    public bool Contains(TValue item) => dictionary.ContainsKey(item.GetKey);

    public TValue Get(TKey key)
    {
        if (!dictionary.TryGetValue(key, out TValue? value))
        {
            throw new Exception($"The {key.ToString()} item is not found.");
        }
        return value;
    }

    /// <summary>
    /// Add a value to the dictionary.
    /// </summary>
    /// <param name="item"></param>
    public override void Add(TValue item)
    {
        TKey key = item.GetKey;
        if (dictionary.TryGetValue(key, out TValue? existingSingletonRepositoryItem))
        {
            throw new Exception($"The {item.GetType().Name} singleton has a duplicate key value of {item.GetKey} with {existingSingletonRepositoryItem.GetType().Name}.");
        }
        dictionary.Add(key, item);
        base.Add(item);
    }

    /// <summary>
    /// Loads the repository with a instance of types that inherit from the TValue type in the assembly.
    /// </summary>
    public override void Load()
    {
        Add(LoadTypesFromAssembly<TValue>());
    }

    /// <summary>
    /// Processes the bind event from the RepositoryCollection by calling the Loaded event for all items in the collection.  Since this is a dictionary repository, all
    /// items must implement the IGetKey interface which also includes the Loaded event handler.
    /// </summary>
    public override void Bind()
    {
        foreach (TValue item in this)
        {
            item.Bind();
        }
    }
}