using System.Collections;

namespace AngbandOS.Core;

[Serializable]
internal class SingletonList<T> : IEnumerable<T>
{
    List<T> list = new List<T>();

    public T this[int index]
    {
        get
        {
            return list[index];
        }
    }

    public int Count => list.Count;

    public WeightedRandom<T> ToWeightedRandom(Func<T, bool>? predicate = null) => new WeightedRandom<T>(this, predicate);

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
    public virtual void Add(T item)
    {
        list.Add(item);
    }

    public SingletonList(SaveGame saveGame, params T[] items)
    {
        foreach (T item in items)
        {
            Add(item);
        }
    }

    public SingletonList(SaveGame saveGame, IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            Add(item);
        }
    }
}
