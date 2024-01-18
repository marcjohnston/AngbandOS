// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal abstract class KeyedDictionaryRepositoryCollection<TKey, TValue> : ListRepositoryCollection<TValue> where TValue : IGetKey<TKey> where TKey : notnull
{
    private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
    protected KeyedDictionaryRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    public bool Contains(TValue item) => dictionary.ContainsKey(item.GetKey);

    public TValue Get(TKey key)
    {
        if (!dictionary.TryGetValue(key, out TValue? value))
        {
            throw new Exception("Item missing from keyed dictionary.");
        }
        return value;
    }

    /// <summary>
    /// Add a value to the keyed dictionary.
    /// </summary>
    /// <param name="item"></param>
    public override void Add(TValue item)
    {
        TKey key = item.GetKey;
        dictionary.Add(key, item);
        base.Add(item);
    }

    public override void Load()
    {
        Add(LoadTypesFromAssembly<TValue>());
    }
}