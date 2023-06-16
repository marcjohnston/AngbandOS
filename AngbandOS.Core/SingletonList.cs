// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
