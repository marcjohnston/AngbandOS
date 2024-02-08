// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

/// <summary>
/// Represents a Repository that uses an internal List<> object to track objects in the repository.  Items in a List
/// repository do not participate in the Loaded phase of the repository life cycle.
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
internal abstract class ListRepository<T> : Repository<T>
{
    private List<T> list = new List<T>();

    protected ListRepository(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns an item in the repository by the ordinal index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T this[int index]
    {
        get
        {
            return list[index];
        }
    }
    public override IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    /// <summary>
    /// Returns the number of items in the repository.
    /// </summary>
    public int Count => list.Count;

    /// <summary>
    /// Returns a WeightedRandom object used to choose an item from the repository.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public WeightedRandom<T> ToWeightedRandom(Func<T, bool>? predicate = null) => new WeightedRandom<T>(SaveGame, this, predicate);

    /// <summary>
    /// Adds an item to the repository.  This is often used to add configured objects.
    /// </summary>
    /// <param name="item"></param>
    public virtual void Add(T item)
    {
        list.Add(item);
    }

    public void Add(params T[] items)
    {
        foreach (T item in items)
        {
            Add(item);
        }
    }

    public void Add(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            Add(item);
        }
    }
}
