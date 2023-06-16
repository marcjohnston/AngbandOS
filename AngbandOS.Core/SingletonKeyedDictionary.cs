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
