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

internal class SaveGameState
{
    private Dictionary<object, int> ObjectToIdDictionary = new Dictionary<object, int>();
    private Dictionary<int, bool> ObjectReferenceCountDictionary = new Dictionary<int, bool>();

    /// <summary>
    /// Returns the object ID for a reference to an existing object, if the object already exists.  If a reference is issued, the reference count for the object is also incremented. 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    private bool TryGetReferenceId(object value, out int id)
    {
        if (ObjectToIdDictionary.TryGetValue(value, out id))
        {
            ObjectReferenceCountDictionary[id] = true;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Registers an object with the dictionary and returns the ID for the object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <remarks>
    /// The object id algorithm (to keep the ID unique, using the next available ID for every subsequent call) is embedded in this method.
    /// </remarks>
    private int RegisterObject(object value)
    {
        int objectId = ObjectToIdDictionary.Count + 1;
        ObjectToIdDictionary.Add(value, objectId);
        return objectId;
    }
    public GameStateBag CreateGameStateBag(bool a, bool b)
    {
        byte value = (byte)((a ? 1 << 0 : 0) | (b ? 1 << 1 : 0));
        return new ByteValueGameStateBag(value);
    }
    public GameStateBag CreateGameStateBag(bool a, bool b, bool c)
    {
        byte value = (byte)((a ? 1 << 0 : 0) | (b ? 1 << 1 : 0) | (c ? 1 << 2 : 0));
        return new ByteValueGameStateBag(value);
    }

    public GameStateBag CreateGameStateBag(bool a, bool b, bool c, bool d)
    {
        byte value = (byte)((a ? 1 << 0 : 0) | (b ? 1 << 1 : 0) | (c ? 1 << 2 : 0) | (d ? 1 << 3 : 0));
        return new ByteValueGameStateBag(value);
    }
    public GameStateBag CreateGameStateBag(bool a, bool b, bool c, bool d, bool e)
    {
        byte value = (byte)((a ? 1 << 0 : 0) | (b ? 1 << 1 : 0) | (c ? 1 << 2 : 0) | (d ? 1 << 3 : 0) | (e ? 1 << 4 : 0));
        return new ByteValueGameStateBag(value);
    }
    public GameStateBag CreateGameStateBag(bool a, bool b, bool c, bool d, bool e, bool f)
    {
        byte value = (byte)((a ? 1 << 0 : 0) | (b ? 1 << 1 : 0) | (c ? 1 << 2 : 0) | (d ? 1 << 3 : 0) | (e ? 1 << 4 : 0) | (f ? 1 << 5 : 0));
        return new ByteValueGameStateBag(value);
    }
    public GameStateBag CreateGameStateBag(bool a, bool b, bool c, bool d, bool e, bool f, bool g)
    {
        byte value = (byte)((a ? 1 << 0 : 0) | (b ? 1 << 1 : 0) | (c ? 1 << 2 : 0) | (d ? 1 << 3 : 0) | (e ? 1 << 4 : 0) | (f ? 1 << 5 : 0) | (g ? 1 << 6 : 0));
        return new ByteValueGameStateBag(value);
    }
    public GameStateBag CreateGameStateBag(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h)
    {
        byte value = (byte)((a ? 1 << 0 : 0) | (b ? 1 << 1 : 0) | (c ? 1 << 2 : 0) | (d ? 1 << 3 : 0) | (e ? 1 << 4 : 0) | (f ? 1 << 5 : 0) | (g ? 1 << 6 : 0) | (h ? 1 << 7 : 0));
        return new ByteValueGameStateBag(value);
    }

    #region Object Creation with Polymorphic Type Support
    private byte? DetermineDerivedId(Type actualType, params Type[] derivedTypes)
    {
#if DEBUG
        if (derivedTypes.Length == 0)
        {
            throw new Exception("Too few derivedTypes");
        }
        else if (derivedTypes.Length > 255)
        {
            throw new Exception("Too many derivedTypes");
        }
#endif
        if (derivedTypes.Length == 1)
        {
            return null;
        }

        byte id = 0;
        foreach (Type derivedType in derivedTypes)
        {
#if DEBUG
            // Ensure the type sent on the parameter list is valid.
            if (!IsCompatible(actualType, derivedType))
            {
                throw new InvalidOperationException($"{actualType.FullName} is not assignable to {derivedType.FullName}");
            }
#endif

            if (actualType == derivedType)
            {
                return id;
            }
            id++;
        }
        throw new Exception($"{actualType.Name} does not match any derived type");
    }

    private static bool IsCompatible(Type actualType, Type derivedType) => actualType.IsAssignableFrom(derivedType) || (actualType.BaseType != null && IsCompatible(actualType.BaseType, derivedType));

    /// <summary>
    /// Creates a reference to an object game state bag with support for polymorphism and derived objects by generating a code that tracks which derived object was serialized.  The order of the supplied types is used to generated the derived code.
    /// At least one type must be supplied.  If only one type is supplied, a default null derived code is generated and not written to the output file.
    /// </summary>
    /// <param name="gameSerializable"></param>
    /// <param name="type">Provide the type for the object to be serialized.</param>
    /// <param name="derivedTypes">Provide all of the additional derived types.  If none are provided, a null derived code will be generated; otherwise, the derived code will be equal to the position of the type specified.</param>
    /// <returns></returns>
    public GameStateBag CreateGameStateBag(IGameSerialize? gameSerializable, Type type, params Type[] derivedTypes)
    {
        if (gameSerializable is null)
        {
            return new NullValueGameStateBag();
        }

        if (TryGetReferenceId(gameSerializable, out int existingId))
        {
            return new ReferenceGameStateBag(existingId);
        }

        // We need to register this object to the dictionary before we serialize the object to prevent recursion.
        int objectId = RegisterObject(gameSerializable);
        DictionaryGameStateBag? gameStateBag = (DictionaryGameStateBag?)gameSerializable.Serialize(this);

        byte? derivedId = DetermineDerivedId(gameSerializable.GetType(), new Type[] { type }.Concat(derivedTypes).ToArray());
        return new DerivedObjectGameStateBag(objectId, derivedId, gameStateBag);
    }

    public GameStateBag CreateGameStateBag(IEnumerable<IGameSerialize?>? gameSerializable, Type type, params Type[] derivedTypes)
    {
        if (gameSerializable is null)
        {
            return new NullValueGameStateBag();
        }

        var gameStateBags = new List<GameStateBag>();
        foreach (IGameSerialize? item in gameSerializable)
        {
            gameStateBags.Add(CreateGameStateBag(item, type, derivedTypes));
        }
        return new ListGameStateBag(gameStateBags.ToArray());
    }

    public GameStateBag CreateGameStateBag(IGameSerialize[][]? gameSerializable, Type type, params Type[] derivedTypes)
    {
        if (gameSerializable is null)
        {
            return new NullValueGameStateBag();
        }

        var gameStateBags = new List<GameStateBag>();
        foreach (IGameSerialize[] item in gameSerializable)
        {
            gameStateBags.Add(CreateGameStateBag(item, type, derivedTypes));
        }
        return new ListGameStateBag(gameStateBags.ToArray());
    }
    #endregion

    public GameStateBag CreateGameStateBag(object? value)
    {
        if (value is null)
        {
            return new NullValueGameStateBag();
        }

        if (value is IGameSerialize gameSerializable)
        {
            if (TryGetReferenceId(gameSerializable, out int existingId))
            {
                return new ReferenceGameStateBag(existingId);
            }

            // We need to register this object to the dictionary before we serialize the object to prevent recursion.
            int objectId = RegisterObject(value);
            DictionaryGameStateBag? gameStateBag = (DictionaryGameStateBag?)gameSerializable.Serialize(this);
            return new ObjectGameStateBag(objectId, gameSerializable.GetType().Name, gameStateBag);
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

        // bool[][]
        if (value is bool[][] arrayOfBools)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (bool[] item in arrayOfBools)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // bool[]
        if (value is bool[] bools)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (bool item in bools)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // byte[][]
        if (value is byte[][] arrayOfBytes)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (byte[] item in arrayOfBytes)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // byte[]
        if (value is byte[] bytes)
        {
            return new ByteArrayGameStateBag(bytes);
        }

        // string[][]
        if (value is string[][] arrayOfStrings)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (string[] item in arrayOfStrings)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // string[]
        if (value is string[] strings)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (string item in strings)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        // enum[]
        if (value is ColorEnum[] colorEnums)
        {
            var gameStateBags = new List<GameStateBag>();
            foreach (ColorEnum item in colorEnums)
            {
                gameStateBags.Add(CreateGameStateBag(item));
            }
            return new ListGameStateBag(gameStateBags.ToArray());
        }

        Type type = value.GetType();
        throw new Exception($"{type.Name} serialization not supported.");
    }

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

