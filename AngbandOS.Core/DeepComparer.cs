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
        public static void DeepEquals(object? actualValue, object? expectedValue)
        {
            var visited = new HashSet<(object, object)>(new ReferenceTupleComparer());
            DeepEqualsInternal(actualValue, expectedValue, visited, "$");
        }

        private static void DeepEqualsInternal(object? actualValue, object? expectedValue, HashSet<(object, object)> visited, string path)
        {
            if (ReferenceEquals(actualValue, expectedValue))
                return;

            if (actualValue is null || expectedValue is null)
               throw new Exception($"Null mismatch at {path}");

            var typeA = actualValue.GetType();
            var typeB = expectedValue.GetType();

            if (typeA != typeB)
            {
                throw new Exception($"Type mismatch at {path}: {typeA.Name} vs {typeB.Name}");
            }

            if (IsSimple(typeA))
            {
                if (!actualValue.Equals(expectedValue))
                {
                    throw new Exception($"Value mismatch at {path}: actual value of {actualValue} vs expected value of {expectedValue}");
                }

                return;
            }

            if (visited.Contains((actualValue, expectedValue)))
                return;

            visited.Add((actualValue, expectedValue));

            // Handle IEnumerable (but skip string)
            if (typeof(IEnumerable).IsAssignableFrom(typeA) && typeA != typeof(string))
            {
                var enumA = ((IEnumerable)actualValue).GetEnumerator();
                var enumB = ((IEnumerable)expectedValue).GetEnumerator();

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
                    var valA = field.GetValue(actualValue);
                    var valB = field.GetValue(expectedValue);

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

