// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AngbandOS.Core;

internal class SaveGameState
{
    private Dictionary<object, int> ObjectToIdDictionary = new Dictionary<object, int>();

    public SaveGameState()
    {
    }

    public GameStateBag CreateGameStateBag(object? value)
    {
        if (value is null)
        {
            return new NullValueGameStateBag();
        }

        if (value is IGameSerialize gameSerializable)
        {
            if (ObjectToIdDictionary.TryGetValue(value, out int existingId))
            {
                return new ReferenceGameStateBag(existingId);
            }

            DictionaryGameStateBag? gameStateBag = gameSerializable.Serialize(this);

            #if DEBUG
            int serializedCount = ((DictionaryGameStateBag?)gameStateBag)?.Values.Count ?? 0;
            // Verify the reflection doesn't have more fields than the IGameSerialize return.
            SaveGameState tempSaveGameState = new SaveGameState();
            GameStateBag singletonGameStateBagViaReflection = tempSaveGameState.SerializeViaReflection(value, "");
            if (((DictionaryGameStateBag)singletonGameStateBagViaReflection).Values.Count > serializedCount)
            {
                Debug.WriteLine($"The number of fields serialized via reflection for {value.GetType().Name} does not match the number of fields serialized via the IGameSerialize interface.  This indicates that the IGameSerialize implementation is not serializing all of the fields in the singleton.  This will cause issues with game state restoration.  Ensure that all fields are being serialized in the IGameSerialize implementation.");
            }
            #endif

            int objectId = ObjectToIdDictionary.Count + 1;
            ObjectToIdDictionary.Add(value, objectId);
            return new ObjectGameStateBag(objectId, value.GetType().Name, ((DictionaryGameStateBag?)gameStateBag)?.Values);
        }

        if (value is IGameSerialize[][] arrayOfArrayOfIGameSerialize)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (IGameSerialize[] item in arrayOfArrayOfIGameSerialize)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        if (value is IEnumerable<IGameSerialize> enumerableOfIGameSerialize)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (IGameSerialize item in enumerableOfIGameSerialize)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        if (value is DateTime dateTimeValue)
        {
            return new DateTimeValueGameStateBag(dateTimeValue);
        }

        if (value is TimeSpan timeSpanValue)
        {
            return new TimeSpanValueGameStateBag(timeSpanValue);
        }

        if (value is string stringValue)
        {
            return new StringValueGameStateBag(stringValue);
        }

        if (value is byte byteValue)
        {
            return new ByteValueGameStateBag(byteValue);
        }

        if (value is char charValue)
        {
            return new CharValueGameStateBag(charValue);
        }

        if (value is decimal decimalValue)
        {
            return new DecimalValueGameStateBag(decimalValue);
        }

        if (value is int intValue)
        {
            return new IntValueGameStateBag(intValue);
        }

        if (value is bool boolValue)
        {
            return new BoolValueGameStateBag(boolValue);
        }

        if (value is Enum)
        {
            return new IntValueGameStateBag((int)value);    
        }

        // char[]
        if (value is char[] charArray)
        {
            return new CharArrayGameStateBag(charArray);
        }

        // int[]
        if (value is int[] intArray)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (int item in intArray)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // bool[]
        if (value is bool[] boolArray)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (bool item in boolArray)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // byte[]
        if (value is byte[] byteArray)
        {
            return new ByteArrayGameStateBag(byteArray);
        }

        if (value is string[] arrayOfString)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (string item in arrayOfString)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        if (value is ColorEnum[] arrayOfColorEnum)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (ColorEnum item in arrayOfColorEnum)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // byte[][]
        if (value is byte[][] arrayOfByteArray)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (byte[] item in arrayOfByteArray)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // string[][]
        if (value is string[][] arrayOfStringArray)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (string[] item in arrayOfStringArray)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        Type type = value.GetType();
        throw new Exception($"{value.GetType().Name} serialization not supported.");
    }

    //public GameStateBag CreateListGameStateBag<T>(IEnumerable<T> list)
    //{
    //    var gameStateBags = new List<GameStateBag>();
    //    foreach (var item in list)
    //    {
    //        gameStateBags.Add(CreateGameStateBag(item));
    //    }
    //    return new ListGameStateBag(gameStateBags.ToArray());
    //}

    public static FieldInfo[] GetAllFields(Type? type)
    {
        List<FieldInfo> fieldInfoList = new List<FieldInfo>();
        while (type != null)
        {
            foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                fieldInfoList.Add(field);
            }

            type = type.BaseType;
        }
        return fieldInfoList.ToArray();
    }

    /// <summary>
    /// Returns the state of a type.  The return object type is dependent on the type of data being serialized.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="_objectToId"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public GameStateBag SerializeViaReflection(object? value, string parent = "")
    {
        // Handle null values.
        if (value is null)
        {
            return new NullValueGameStateBag();
        }

        if (value is DateTime dateTimeValue)
        {
            return new DateTimeValueGameStateBag(dateTimeValue);
        }

        if (value is TimeSpan timeSpanValue)
        {
            return new TimeSpanValueGameStateBag(timeSpanValue);
        }

        if (value is string stringValue)
        {
            return new StringValueGameStateBag(stringValue);
        }

        if (value is byte byteValue)
        {
            return new ByteValueGameStateBag(byteValue);
        }

        if (value is char charValue)
        {
            return new CharValueGameStateBag(charValue);
        }

        if (value is decimal decimalValue)
        {
            return new DecimalValueGameStateBag(decimalValue);
        }

        if (value is int intValue)
        {
            return new IntValueGameStateBag(intValue);
        }

        if (value is bool boolValue)
        {
            return new BoolValueGameStateBag(boolValue);
        }

        if (value is Enum)
        {
            return new IntValueGameStateBag((int)value);
        }

        Type type = value.GetType();

        // Object identity--game objects only
        if (type.Assembly == typeof(GameStateBag).Assembly)
        {
            // Retrieve all of the fields to be preserved.  We exclude property backing fields and fields marked as [NonSerialized].
            FieldInfo[] allFields = GetAllFields(type);
            IEnumerable<FieldInfo> serializableFields = allFields.Where(p => !p.IsDefined(typeof(CompilerGeneratedAttribute), true) && !System.Attribute.IsDefined(p, typeof(NonSerializedAttribute)));
            var objectValue = new Dictionary<string, GameStateBag>();

            foreach (FieldInfo childFieldInfo in serializableFields)
            {
                // Get the key and value and type of the field.
                string key = childFieldInfo.Name;
                object? fieldValue = childFieldInfo.GetValue(value);
                objectValue[key] = SerializeViaReflection(fieldValue, StringLibrary.DelimitIf(parent, ".", $"{type.Name}.{key}"));
            }

            return new DictionaryGameStateBag(objectValue);
        }

        // Dictionaries
        if (value is IDictionary dictionary)
        {
            var result = new Dictionary<string, GameStateBag>();

            foreach (DictionaryEntry entry in dictionary)
            {
                string key = entry.Key.ToString()!; // Dictionary keys can never be null.
                result[key] = SerializeViaReflection(entry.Value, StringLibrary.DelimitIf(parent, ".", key));
            }

            return new DictionaryGameStateBag(result);
        }

        // Tuples
        if (type.Namespace == "System" && (type.Name.StartsWith("ValueTuple`") || type.Name.StartsWith("Tuple`")))
        {
            var values = new List<GameStateBag>();

            var fields = type.GetFields();

            foreach (var field in fields)
            {
                values.Add(SerializeViaReflection(field.GetValue(value), StringLibrary.DelimitIf(parent, ".", field.Name)));
            }

            return new TupleGameStateBag(type.Name, values.ToArray());
        }

        // Char[]
        if (value is char[] charArray)
        {
            return new CharArrayGameStateBag(charArray);
        }

        // Byte[]
        if (value is byte[] byteArray)
        {
            return new ByteArrayGameStateBag(byteArray);
        }


        // Queue<string>
        if (value is Queue<string> queueOfString)
        {
            return new QueueOfStringGameStateBag(queueOfString.ToArray());
        }

        // Collections
        if (value is IEnumerable enumerable && value is not string)
        {
            var list = new List<GameStateBag>();

            int index = 0;
            foreach (var item in enumerable)
            {
                list.Add(SerializeViaReflection(item, $"{parent}[{index}]"));
                index++;
            }

            return new ListGameStateBag(list.ToArray());
        }

        throw new Exception($"{type.Name} serialization not supported on field {parent}.");
    }
    public static class DeepComparer
    {
        public static bool DeepEquals(object? a, object? b)
        {
            var visited = new HashSet<(object, object)>(new ReferenceTupleComparer());
            return DeepEqualsInternal(a, b, visited);
        }

        private static bool DeepEqualsInternal(object? a, object? b, HashSet<(object, object)> visited)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a == null || b == null)
                return false;

            var typeA = a.GetType();
            var typeB = b.GetType();

            if (typeA != typeB)
                return false;

            if (IsSimple(typeA))
                return a.Equals(b);

            if (visited.Contains((a, b)))
                return true;

            visited.Add((a, b));

            // Handle IEnumerable (but skip string)
            if (typeof(IEnumerable).IsAssignableFrom(typeA) && typeA != typeof(string))
            {
                var enumA = ((IEnumerable)a).GetEnumerator();
                var enumB = ((IEnumerable)b).GetEnumerator();

                while (true)
                {
                    var hasA = enumA.MoveNext();
                    var hasB = enumB.MoveNext();

                    if (hasA != hasB)
                        return false;

                    if (!hasA)
                        break;

                    if (!DeepEqualsInternal(enumA.Current, enumB.Current, visited))
                        return false;
                }

                return true;
            }

            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            // Compare fields
            foreach (var field in typeA.GetFields(flags))
            {
                var valA = field.GetValue(a);
                var valB = field.GetValue(b);

                if (!DeepEqualsInternal(valA, valB, visited))
                    return false;
            }

            // Compare properties
            foreach (var prop in typeA.GetProperties(flags))
            {
                if (prop.GetIndexParameters().Length > 0)
                    continue; // skip indexers

                if (!prop.CanRead)
                    continue;

                var valA = prop.GetValue(a);
                var valB = prop.GetValue(b);

                if (!DeepEqualsInternal(valA, valB, visited))
                    return false;
            }

            return true;
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

