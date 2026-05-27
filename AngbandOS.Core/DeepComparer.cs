// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AngbandOS.Core;

internal partial class SaveGameState
{
    public static class DeepComparer
    {
        public static void DeepEquals(object? a, object? b)
        {
            var visited = new HashSet<(object, object)>(new ReferenceTupleComparer());
            DeepEqualsInternal(a, b, visited, "$");
        }

        private static void DeepEqualsInternal(object? a, object? b, HashSet<(object, object)> visited, string path)
        {
            if (ReferenceEquals(a, b))
                return;

            if (a is null || b is null)
               throw new Exception($"Null mismatch at {path}");

            var typeA = a.GetType();
            var typeB = b.GetType();

            if (typeA != typeB)
            {
                throw new Exception($"Type mismatch at {path}: {typeA.Name} vs {typeB.Name}");
            }

            if (IsSimple(typeA))
            {
                if (!a.Equals(b))
                {
                    throw new Exception($"Value mismatch at {path}: {a} vs {b}");
                }

                return;
            }

            if (visited.Contains((a, b)))
                return;

            visited.Add((a, b));

            // Handle IEnumerable (but skip string)
            if (typeof(IEnumerable).IsAssignableFrom(typeA) && typeA != typeof(string))
            {
                var enumA = ((IEnumerable)a).GetEnumerator();
                var enumB = ((IEnumerable)b).GetEnumerator();

                int index = 0;
                while (true)
                {
                    var hasA = enumA.MoveNext();
                    var hasB = enumB.MoveNext();

                    if (hasA != hasB)
                    {
                        throw new Exception($"Collection length mismatch at {path}");

                    }

                    if (!hasA)
                    {
                        break;
                    }

                    DeepEqualsInternal(enumA.Current, enumB.Current, visited, $"{path}.{typeA.Name}[{index}]");
                    index++;
                }

                return;
            }

            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            // Compare fields
            foreach (var field in typeA.GetFields(flags))
            {
                if (!field.IsNotSerialized)
                {
                    var valA = field.GetValue(a);
                    var valB = field.GetValue(b);

                    DeepEqualsInternal(valA, valB, visited, $"{path}.{typeA.Name}");
                }
            }
            return;
        }

        private static bool IsSimple(Type type)
        {
            return type.IsPrimitive
                   || type.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal)
                   || type == typeof(DateTime)
                   || type == typeof(Guid)
                   || type == typeof(TimeSpan);
        }
        private class ReferenceTupleComparer : IEqualityComparer<(object, object)>
        {
            public bool Equals((object, object) x, (object, object) y)
            {
                return ReferenceEquals(x.Item1, y.Item1) && ReferenceEquals(x.Item2, y.Item2);
            }

            public int GetHashCode((object, object) obj)
            {
                unchecked
                {
                    return (RuntimeHelpers.GetHashCode(obj.Item1) * 397) ^ RuntimeHelpers.GetHashCode(obj.Item2);
                }
            }
        }
    }
}

