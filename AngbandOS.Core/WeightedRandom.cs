// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an object capable of picking items from a weighted list.  The items in the list can be added specify varying and specific weights.  This object stores the weights
/// of the objects as opposed to enumerating copies into large arrays.  This results in an add of item with O(1) and a choice selection process of O(n).
/// </summary>
/// <remarks>
/// Example:
/// We add three letters with weights of 3, 2 and 1.
/// Add(3, "A")
/// Add(2, "B")
/// Add(1, "C")
/// 
/// An enumeration would look like:
/// 0 - A
/// 1 - A
/// 2 - A
/// 3 - B
/// 4 - B
/// 5 - C
/// 
/// Our internal structure will look like:
/// _list[index]<sum, T> 
/// _list[0]<3, "A"> // 0 + 3 "A"s
/// _list[1]<5, "B"> // previous 3 + 2 "B"s
/// _list[2]<6, "C"> // previos 5 + 1 "C"
/// 
/// Our choice selections are from 0 .. 5
/// During the choice phase, we enumerate the _list indexes.  If the choice is greater than or equal to the key, we go to the index index.
/// The last item in the list is guaranteed to have a value greater than the max choice.
/// </remarks>
/// <typeparam name="T"></typeparam>
[Serializable]
internal class WeightedRandom<T>
{
    protected readonly Game Game;
    private readonly List<KeyValuePair<int, T>> _list = new List<KeyValuePair<int, T>>();
    private int _sum = 0;

    /// <summary>
    /// Creates a new empty weighted-random.  Use the Add method to add items to the list.
    /// </summary>
    /// <param name="game"></param>
    public WeightedRandom(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Creates a new evenly-distributed weighted-random from a list of objects using a predicate function to determine if each item in the list should be included or excluded.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="values"></param>
    /// <param name="predicate"></param>
    [Obsolete("The predicate should modify the list to be sent to the constructor.")]
    public WeightedRandom(Game game, IEnumerable<T> values, Func<T, bool>? predicate) // TODO: The predicate should be an extension that returns the IEnumerable values not integrated into this constructor.
    {
        Game = game;
        foreach (T value in values)
        {
            if (predicate == null || predicate(value))
            {
                Add(1, value);
            }
        }
    }

    /// <summary>
    /// Creates a new evenly-distributed weighted-random from a list of objects.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="values"></param>
    public WeightedRandom(Game game, IEnumerable<T> values)
    {
        Game = game;
        foreach (T value in values)
        {
            Add(1, value);
        }
    }

    /// <summary>
    /// Creates a new weighted-random from a given set of tuples.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="values"></param>
    public WeightedRandom(Game game, IEnumerable<(T Item, int Weight)> values)
    {
        Game = game;
        foreach ((T Item, int Weight) value in values)
        {
            Add(value.Weight, value.Item);
        }
    }

    public void Add(int weight, params T[] values)
    {
        foreach (T value in values)
        {
            _sum += weight;
            _list.Add(new KeyValuePair<int, T>(_sum, value));
        }
    }

    /// <summary>
    /// Chooses and returns a random item from the weighted list.  Throws an exception, if the list is empty.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T Choose()
    {
        T? t = ChooseOrDefault();
        if (t == null)
        {
            throw new Exception("No options exist for choice.");
        }
        return t;
    }

    /// <summary>
    /// Chooses and returned a random item from the weighted list; or null, if the list is empty.
    /// </summary>
    /// <returns></returns>
    public T? ChooseOrDefault()
    {
        if (_list.Count == 0)
        {
            return default;
        }
        int choice = Game.RandomLessThan(_sum);
        int index = 0;
        while (choice >= _list[index].Key) // This is because there are weights.  The keys are used to track weights.
        {
            index++;
        }
        return _list[index].Value;
    }
}
