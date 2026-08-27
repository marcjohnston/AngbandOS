// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Collections;

namespace AngbandOS.Core;

public static class CartesianProduct
{
    public static IEnumerable<(T1, T2)> Generate<T1, T2>(IEnumerable<T1> t1Collection, IEnumerable<T2> t2Collection)
    {
        foreach (var item in GenericGenerate(t1Collection, t2Collection))
        {
            yield return ((T1)item[0], (T2)item[1]);
        }
    }

    public static IEnumerable<(T1, T2, T3)> Generate<T1, T2, T3>(IEnumerable<T1> t1Collection, IEnumerable<T2> t2Collection, IEnumerable<T3> t3Collection)
    {
        foreach (var item in GenericGenerate(t1Collection, t2Collection, t3Collection))
        {
            yield return ((T1)item[0], (T2)item[1], (T3)item[2]);
        }
    }

    public static IEnumerable<(T1, T2, T3, T4)> Generate<T1, T2, T3, T4>(IEnumerable<T1> t1Collection, IEnumerable<T2> t2Collection, IEnumerable<T3> t3Collection, IEnumerable<T4> t4Collection)
    {
        foreach (var item in GenericGenerate(t1Collection, t2Collection, t3Collection, t4Collection))
        {
            yield return ((T1)item[0], (T2)item[1], (T3)item[2], (T4)item[3]);
        }
    }

    public static IEnumerable<(T1, T2, T3, T4, T5)> Generate<T1, T2, T3, T4, T5>(IEnumerable<T1> t1Collection, IEnumerable<T2> t2Collection, IEnumerable<T3> t3Collection, IEnumerable<T4> t4Collection, IEnumerable<T5> t5Collection)
    {
        foreach (var item in GenericGenerate(t1Collection, t2Collection, t3Collection, t4Collection, t5Collection))
        {
            yield return ((T1)item[0], (T2)item[1], (T3)item[2], (T4)item[3], (T5)item[4]);
        }
    }

    private static IEnumerable<object[]> GenericGenerate(params IEnumerable[] collections)
    {
        if (collections == null)
            throw new ArgumentNullException(nameof(collections));

        var arrays = collections
            .Select(c => c.Cast<object>().ToArray())
            .ToArray();

        if (arrays.Length == 0)
        {
            yield return Array.Empty<object>();
            yield break;
        }

        var indices = new int[arrays.Length];

        while (true)
        {
            var result = new object[arrays.Length];

            for (int i = 0; i < arrays.Length; i++)
                result[i] = arrays[i][indices[i]];

            yield return result;

            int position = arrays.Length - 1;

            while (position >= 0)
            {
                indices[position]++;

                if (indices[position] < arrays[position].Length)
                    break;

                indices[position] = 0;
                position--;
            }

            if (position < 0)
                yield break;
        }
    }
}