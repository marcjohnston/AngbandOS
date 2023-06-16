// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections;

namespace AngbandOS.Core;

[Obsolete("Use SingletonDictionary ... need to add the ISingletonDictionary<T> interface functionality for the GetKey method to the SingletonDictionary first.")]
[Serializable]
internal class SingletonKeyedDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> where TValue : ISingletonDictionary<TKey>
{
    private SaveGame SaveGame;
    Dictionary<TKey, TValue> instances = new Dictionary<TKey, TValue>();
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return instances.GetEnumerator();
    }

    public void Add(TValue item)
    {
        TKey key = item.GetKey;
        instances.Add(key, item);
    }

    public SingletonKeyedDictionary(SaveGame saveGame, TValue[] items)
    {
        SaveGame = saveGame;
        foreach (TValue item in items)
        {
            Add(item);
        }
    }

    public SingletonKeyedDictionary(SaveGame saveGame, Dictionary<TKey, TValue> dictionary)
    {
        instances = dictionary;
    }
}
