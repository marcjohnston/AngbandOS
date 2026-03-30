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

internal partial class Game
{
    public static class GameStateVerifier
    {
        public static void Verify(object original, object restored)
        {
            var visited = new HashSet<(object, object)>(new ReferenceTupleComparer());
            CompareObjects(original, restored, "root", visited);
        }

        private static void CompareObjects(object? a, object? b, string path, HashSet<(object, object)> visited)
        {
            if (ReferenceEquals(a, b))
                return;

            if (a is null || b is null)
                throw new Exception($"Mismatch at {path}: one is null");

            var type = a.GetType();

            if (type != b.GetType())
                throw new Exception($"Type mismatch at {path}: {type} != {b.GetType()}");

            if (IsPrimitive(type))
            {
                if (!a.Equals(b))
                    throw new Exception($"Value mismatch at {path}: {a} != {b}");
                return;
            }

            if (visited.Contains((a, b)))
                return;

            visited.Add((a, b));

            if (a is IEnumerable enumA && b is IEnumerable enumB)
            {
                var enumAList = enumA.Cast<object?>().ToList();
                var enumBList = enumB.Cast<object?>().ToList();

                if (enumAList.Count != enumBList.Count)
                    throw new Exception($"Collection size mismatch at {path}");

                for (int i = 0; i < enumAList.Count; i++)
                {
                    CompareObjects(enumAList[i], enumBList[i], $"{path}[{i}]", visited);
                }

                return;
            }

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var valA = field.GetValue(a);
                var valB = field.GetValue(b);

                CompareObjects(valA, valB, $"{path}.{field.Name}", visited);
            }
        }

        private static bool IsPrimitive(Type type)
        {
            return type.IsPrimitive
                    || type == typeof(string)
                    || type == typeof(decimal)
                    || type == typeof(DateTime)
                    || type == typeof(Guid);
        }

        private class ReferenceTupleComparer : IEqualityComparer<(object, object)>
        {
            public bool Equals((object, object) x, (object, object) y)
            {
                return ReferenceEquals(x.Item1, y.Item1) && ReferenceEquals(x.Item2, y.Item2);
            }

            public int GetHashCode((object, object) obj)
            {
                return RuntimeHelpers.GetHashCode(obj.Item1) ^ RuntimeHelpers.GetHashCode(obj.Item2);
            }
        }
    }
}