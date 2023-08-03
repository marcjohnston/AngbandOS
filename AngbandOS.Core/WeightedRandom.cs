// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

internal class WeightedRandom<T>
{
    private Dictionary<int, T> dictionary = new Dictionary<int, T>();

    public WeightedRandom() { }

    public WeightedRandom(IEnumerable<T> values, Func<T, bool>? predicate)
    {
        foreach (T value in values)
        {
            if (predicate == null || predicate(value))
            {
                Add(1, value);
            }
        }
    }

    public WeightedRandom(IEnumerable<T> values)
    {
        foreach (T value in values)
        {
            Add(1, value);
        }
    }

    public void Add(int weight, params T[] values)
    {
        for (int i = 0; i < weight; i++)
        {
            foreach (T value in values)
            {
                dictionary.Add(dictionary.Count, value);
            }
        }
    }
    public T? Choose()
    {
        if (dictionary.Count == 0)
        {
            return default;
        }
        int choice = Program.Rng.RandomLessThan(dictionary.Count);
        return dictionary[choice];
    }
}
