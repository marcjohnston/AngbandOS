// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal abstract class KeyedDictionaryRepositoryCollection<TKey, TValue> : ListRepositoryCollection<TValue> where TValue : IConfigurationItem, ISingletonKeyedDictionary<TKey>
{
    Dictionary<TKey, TValue> instances = new Dictionary<TKey, TValue>();
    protected KeyedDictionaryRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

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

    public void Add(TValue item)
    {
        TKey key = item.GetKey;
        instances.Add(key, item);
    }

    public void Add(TValue[] items)
    {
        foreach (TValue item in items)
        {
            Add(item);
        }
    }

    public void Add(Dictionary<TKey, TValue> dictionary)
    {
        instances = dictionary;
    }

    public override void Load()
    {
        Add(LoadTypesFromAssembly<TValue>());
    }
}