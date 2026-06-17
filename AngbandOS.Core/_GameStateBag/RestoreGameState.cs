// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Reflection;

namespace AngbandOS.Core;

/// <summary>
/// Represents the object for restoring game state values.  It keeps a reference to the dictionary used to track object creation. 
/// </summary>
internal class RestoreGameState
{
    private Game Game { get; }
    private Dictionary<int, object> ObjectIdToReferenceDictionary { get; }
    private Dictionary<int, GameStateBag> ObjectIdToObjectGameStateBagDictionary { get; }
    public GameStateBag GameStateBag { get; }
    private int CurrentSequentialIndex = 0;

    /// <summary>
    /// Creates a clone of the RestoreGameState with a new game state bag.  Only the New method should utilize this constructor.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="objectIdToReferenceDictionary"></param>
    /// <param name="gameStateBag"></param>
    private RestoreGameState(Game game, Dictionary<int, object> objectIdToReferenceDictionary, Dictionary<int, GameStateBag> objectIdToObjectGameStateBagDictionary, GameStateBag gameStateBag)
    {
        Game = game;
        ObjectIdToReferenceDictionary = objectIdToReferenceDictionary;
        ObjectIdToObjectGameStateBagDictionary = objectIdToObjectGameStateBagDictionary;
        GameStateBag = gameStateBag;
    }

    /// <summary>
    /// Creates a new instance of the RestoreGameState class.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="gameStateBag"></param>
    public RestoreGameState(Game game, GameStateBag gameStateBag)
    {
        Game = game;
        ObjectIdToReferenceDictionary = new Dictionary<int, object>();
        ObjectIdToObjectGameStateBagDictionary = new Dictionary<int, GameStateBag>();
        GameStateBag = gameStateBag;
    }

    public void TrackObject(int objectId, object singleton)
    {
        // We are tracking the object for the first time.  We will add it to the dictionary.  It is possible that we are tracking a reference before we have the object game state bag, so we will allow the object game state bag to be null for now and update it later when we have it.
        ObjectIdToReferenceDictionary.Add(objectId, singleton);
    }

    public void TrackGameStateBag(int objectId, GameStateBag objectGameStateBag)
    {
        ObjectIdToObjectGameStateBagDictionary.Add(objectId, objectGameStateBag);
    }

    public object GetObjectById(int objectId)
    {
        return ObjectIdToReferenceDictionary[objectId];
    }

    public RestoreGameState New(GameStateBag gameStateBag)
    {
        return new RestoreGameState(Game, ObjectIdToReferenceDictionary, ObjectIdToObjectGameStateBagDictionary, gameStateBag);
    }

    public bool Verify(object? singleton)
    {
#if DEBUG
        return GameStateBag.Verify(this, singleton);
#else
        return true;
#endif
    }

    public GameStateBag GetObjectGameStateBag(int objectId)
    {
        return ObjectIdToObjectGameStateBagDictionary[objectId];
    }

    public RestoreGameState GetByKey(string key)
    {
        if (GameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            GameStateBag? gameStateBag = objectGameStateBag.GetByKey(key, CurrentSequentialIndex);
            if (gameStateBag is null)
            {
                throw new KeyNotFoundException($"Key {key} not found in object game state bag with object id {objectGameStateBag.ObjectId}.");
            }

            CurrentSequentialIndex++;
            return New(gameStateBag);
        }
        if (GameStateBag is DerivedObjectGameStateBag derivedObjectGameStateBag)
        {
            GameStateBag? gameStateBag = derivedObjectGameStateBag.GetByKey(key, CurrentSequentialIndex);
            if (gameStateBag is null)
            {
                throw new KeyNotFoundException($"Key {key} not found in object game state bag with object id {derivedObjectGameStateBag.ObjectId}.");
            }

            CurrentSequentialIndex++;
            return New(gameStateBag);
        }
        if (GameStateBag is DictionaryGameStateBag dictionaryGameStateBag)
        {
            GameStateBag? gameStateBag = dictionaryGameStateBag.GetByKey(key, CurrentSequentialIndex);
            if (gameStateBag is null)
            {
                throw new KeyNotFoundException($"Key {key} not found in dictionary game state bag.");
            }

            CurrentSequentialIndex++;
            return New(gameStateBag);
        }
        throw new InvalidOperationException($"GameStateBag is not of type {nameof(ObjectGameStateBag)} or {nameof(DictionaryGameStateBag)}.");
    }

    public int GetObjectId()
    {
        if (GameStateBag is DerivedObjectGameStateBag singletonDerivedObjectGameStateBag)
        {
            return singletonDerivedObjectGameStateBag.ObjectId;
        }
        if (GameStateBag is ObjectGameStateBag singletonObjectGameStateBag)
        {
            return singletonObjectGameStateBag.ObjectId;
        }
        if (GameStateBag is ReferenceGameStateBag singletonReferenceGameStateBag)
        {
            return singletonReferenceGameStateBag.ObjectId;
        }
        throw new Exception($"The restore game state is not an {nameof(ObjectGameStateBag)}, a {nameof(DerivedObjectGameStateBag)} or a {nameof(ReferenceGameStateBag)}.");
    }

    public bool GetBool() => ((BoolValueGameStateBag)GameStateBag).Value;

    public T GetEnum<T>() where T : Enum
    {
        int value = GetInt();
        if (Enum.IsDefined(typeof(T), value))
        {
            return (T)(object)value;
        }
        throw new ArgumentOutOfRangeException(nameof(value), $"Invalid value for {typeof(T).Name}: {value}");
    }

    public T[] GetEnums<T>() where T : Enum
    {
        ListGameStateBag listGameStateBag = (ListGameStateBag)GameStateBag;
        List<T> boolList = new List<T>();
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            if (gameStateBag is not IntValueGameStateBag intValueGameStateBag)
            {
                throw new Exception($"Expected int value game state bag for enum.");
            }
            int value = intValueGameStateBag.Value;
            if (!Enum.IsDefined(typeof(T), value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Invalid value for enum {typeof(T).Name}: {value}");
            }
            T enumValue = (T)(object)value;
            boolList.Add(enumValue);
        }
        return boolList.ToArray();
    }

    public (bool a, bool b) Get2Bools()
    {
        byte value = ((ByteValueGameStateBag)GameStateBag).Value;
        return ((value & (1 << 0)) != 0, (value & (1 << 1)) != 0);
    }
    public (bool a, bool b, bool c) Get3Bools()
    {
        byte value = ((ByteValueGameStateBag)GameStateBag).Value;
        return ((value & (1 << 0)) != 0, (value & (1 << 1)) != 0, (value & (1 << 2)) != 0);
    }
    public (bool a, bool b, bool c, bool d) Get4Bools()
    {
        byte value = ((ByteValueGameStateBag)GameStateBag).Value;
        return ((value & (1 << 0)) != 0, (value & (1 << 1)) != 0, (value & (1 << 2)) != 0, (value & (1 << 3)) != 0);
    }
    public (bool a, bool b, bool c, bool d, bool e) Get5Bools()
    {
        byte value = ((ByteValueGameStateBag)GameStateBag).Value;
        return ((value & (1 << 0)) != 0, (value & (1 << 1)) != 0, (value & (1 << 2)) != 0, (value & (1 << 3)) != 0, (value & (1 << 4)) != 0);
    }
    public (bool a, bool b, bool c, bool d, bool e, bool f) Get6Bools()
    {
        byte value = ((ByteValueGameStateBag)GameStateBag).Value;
        return ((value & (1 << 0)) != 0, (value & (1 << 1)) != 0, (value & (1 << 2)) != 0, (value & (1 << 3)) != 0, (value & (1 << 4)) != 0, (value & (1 << 5)) != 0);
    }
    public (bool a, bool b, bool c, bool d, bool e, bool f, bool g) Get7Bools()
    {
        byte value = ((ByteValueGameStateBag)GameStateBag).Value;
        return ((value & (1 << 0)) != 0, (value & (1 << 1)) != 0, (value & (1 << 2)) != 0, (value & (1 << 3)) != 0, (value & (1 << 4)) != 0, (value & (1 << 5)) != 0, (value & (1 << 6)) != 0);
    }
    public (bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h) Get8Bools()
    {
        byte value = ((ByteValueGameStateBag)GameStateBag).Value;
        return ((value & (1 << 0)) != 0, (value & (1 << 1)) != 0, (value & (1 << 2)) != 0, (value & (1 << 3)) != 0, (value & (1 << 4)) != 0, (value & (1 << 5)) != 0, (value & (1 << 6)) != 0, (value & (1 << 7)) != 0);
    }

    public bool[] GetBools()
    {
        ListGameStateBag listGameStateBag = (ListGameStateBag)GameStateBag;
        List<bool> boolList = new List<bool>();
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            if (gameStateBag is not BoolValueGameStateBag boolValueGameStateBag)
            {
                throw new Exception($"Expected bool value game state bag");
            }
            boolList.Add(boolValueGameStateBag.Value);
        }
        return boolList.ToArray();
    }

    public T CreateObject<T>(int objectId, ObjectGameStateBag objectGameStateBag)
    {
        var fullyQualifiedName = $"{typeof(Game).Assembly.GetName().Name}.Core.{objectGameStateBag.TypeName}";
        Type? type = Type.GetType(fullyQualifiedName);
        if (type is null)
        {
            throw new Exception($"{fullyQualifiedName} type not found.  Ensure it is in the Core namespace.");
        }
        RestoreGameState restoreGameState = New(objectGameStateBag);
        try
        {
            T? t = (T?)Activator.CreateInstance(type, Game, restoreGameState);
            if (t is null)
            {
                throw new Exception($"Unable to instantiate a new {objectGameStateBag.TypeName}.");
            }
            TrackObject(objectId, t);
            return t;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error during construction of a {type.Name}({nameof(Game)}, {nameof(RestoreGameState)}.  {ex.Message}");
        }
    }

    #region Derived New Object Serialization
    public T? GetDerivedReferenceOrDefault<T>(params Func<RestoreGameState, T>[] constructors)
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }

        return GetDerivedReference(constructors);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Provide the type to convert the return object to.</typeparam>
    /// <param name="constructors">Provide the functionality to construct any applicable objects.  The constructors must be provided in the same order as the types that were provided during serialization.  If only references are expected, no constructors need to be supplied.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public T GetDerivedReference<T>(params Func<RestoreGameState, T>[] constructors)
    {
        // Check to see if the singleton game state bag is a reference.  This will occur when the singleton was already serialized from a previous singleton.
        if (GameStateBag is ReferenceGameStateBag referenceGameStateBag)
        {
            // This is a reference game state bag.  Retrieve the object id and check to see if the object is already being tracked.
            int objectId = referenceGameStateBag.ObjectId;
            if (ObjectIdToReferenceDictionary.TryGetValue(objectId, out object? singleton))
            {
                // We need to track the object.  Since this is a reference game state bag, we do not have the object game state bag yet and will pass null.
                T typedReference = (T)singleton;
                return typedReference;
            }
            throw new Exception("Reference ID not found in ObjectIdToReferenceDictionary.");
        }
        else if (GameStateBag is DerivedObjectGameStateBag derivedObjectGameStateBag)
        {
            // This is a derived object game state bag.  The derived object might already exist because the object was serialized early.
            int objectId = derivedObjectGameStateBag.ObjectId;
            if (ObjectIdToReferenceDictionary.TryGetValue(objectId, out object? singleton))
            {
                T typedReference = (T)singleton;
                TrackGameStateBag(objectId, derivedObjectGameStateBag);
                return typedReference;
            }

            RestoreGameState restoreGameState = New(derivedObjectGameStateBag);

            // We use the derived id to select the appropriate constructor.
            if (derivedObjectGameStateBag.DerivedId < 0 || derivedObjectGameStateBag.DerivedId >= constructors.Length)
            {
                throw new Exception($"Derived ID#{derivedObjectGameStateBag.DerivedId} does not have a constructor.");
            }

            Func<RestoreGameState, T> constructor;
            if (derivedObjectGameStateBag.DerivedId is null)
            {
#if DEBUG
                if (constructors.Length == 0)
                {
                    throw new Exception($"No constructor was supplied to generate a {typeof(T).Name}.  The passing of no constructors in the arguments is only valid when the game object already exists at this restore step.  In that case this restore can return an existing reference without need for construction but no reference was found for this object.  This object was serialized as non-polymorphic, so exactly one constructor must be supplied.");
                }
                if (constructors.Length != 1)
                {
                    throw new Exception($"Too many constructors were supplied to generate a {typeof(T).Name}.  {typeof(T).Name} was serialized without polymorphic support.");
                }
#endif
                constructor = constructors[0];
            }
            else
            {
                constructor = constructors[derivedObjectGameStateBag.DerivedId.Value];
            }
            T t = constructor(restoreGameState);
            TrackObject(objectId, t);
            return t;
        }
        throw new InvalidOperationException($"{typeof(GameStateBag).Name} is not of type {nameof(DerivedObjectGameStateBag)} or {nameof(ReferenceGameStateBag)}.");
    }

    public T[] GetDerivedReferences<T>(params Func<RestoreGameState, T>[] constructors)
    {
        List<T> list = new List<T>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            RestoreGameState restoreGameState = New(gameStateBag);
            T t = restoreGameState.GetDerivedReference<T>(constructors);
            list.Add(t);
        }
        return list.ToArray();
    }

    public T[]? GetDerivedReferencesOrDefault<T>(params Func<RestoreGameState, T>[] constructors)
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }

        return GetDerivedReferences(constructors);
    }

    public T[][] GetArrayOfDerivedReferences<T>(params Func<RestoreGameState, T>[] constructors)
    {
        List<T[]> listOfReferences = new List<T[]>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is not ListGameStateBag listOfStringsBag)
            {
                throw new Exception($"Jagged array of {typeof(T).Name} not a list.");
            }
            RestoreGameState referencesRestoreGameState = New(gameStateBag);
            T[] references = referencesRestoreGameState.GetDerivedReferences<T>(constructors);
            listOfReferences.Add(references);
        }
        return listOfReferences.ToArray();
    }

    public T?[] GetNullableDerivedReferences<T>(params Func<RestoreGameState, T>[] constructors)
    {
        List<T?> list = new List<T?>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is NullValueGameStateBag)
            {
                list.Add(default);
            }
            else
            {
                RestoreGameState restoreGameState = New(gameStateBag);
                T t = restoreGameState.GetDerivedReference<T>(constructors);
                list.Add(t);
            }
        }
        return list.ToArray();
    }
    #endregion

    public T GetReference<T>()
    {
#if DEBUG
        // We will only check game serializable models and not IGetKey.
        if (!typeof(IGetKey).IsAssignableFrom(typeof(T)) && !typeof(T).IsAbstract)
        {
            ConstructorInfo? gameAndRestoreGameStateConstructor = typeof(T).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new[] { typeof(Game), typeof(RestoreGameState) }, null);
            if (gameAndRestoreGameStateConstructor is null)
            {
                throw new Exception($"Model for {typeof(T).Name} does not have public constructor for (Game, RestoreGameState).");
            }
        }
#endif

        // Check to see if the singleton game state bag is a reference.  This will occur when the singleton was already serialized from a previous singleton.
        if (GameStateBag is ReferenceGameStateBag referenceGameStateBag)
        {
            // This is a reference game state bag.  Retrieve the object id and check to see if the object is already being tracked.
            int objectId = referenceGameStateBag.ObjectId;
            if (ObjectIdToReferenceDictionary.TryGetValue(objectId, out object? singleton))
            {
#if DEBUG
                if (!typeof(T).IsAssignableFrom(singleton.GetType()))
                {
                    throw new InvalidOperationException($"Reference is not of type {typeof(T).Name}.");
                }
#endif

                // We need to track the object.  Since this is a reference game state bag, we do not have the object game state bag yet and will pass null.
                T typedReference = (T)singleton;
                return typedReference;
            }
            throw new Exception("Reference ID not found in ObjectIdToReferenceDictionary.");
        }
        else if (GameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            // This is an object game state bag.  The object might already exist because the object was serialized early.
            int objectId = objectGameStateBag.ObjectId;
            if (ObjectIdToReferenceDictionary.TryGetValue(objectId, out object? singleton))
            {
#if DEBUG
                // The object already exists, even though we now have the object game state bag.  We will need to track this object game state bag for the bind phase.
                if (!typeof(T).IsAssignableFrom(singleton.GetType()))
                {
                    throw new InvalidOperationException($"Reference is not of type {typeof(T).Name}.");
                }
#endif

                T typedReference = (T)singleton;
                TrackGameStateBag(objectId, objectGameStateBag);
                return typedReference;
            }

            return CreateObject<T>(objectId, objectGameStateBag);
        }
        throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name} or {typeof(ReferenceGameStateBag).Name}.");
    }

    public T? GetReferenceOrDefault<T>()
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetReference<T>();
    }

    public T[] GetReferences<T>()
    {
        List<T> list = new List<T>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            RestoreGameState restoreGameState = New(gameStateBag);
            T t = restoreGameState.GetReference<T>();
            list.Add(t);
        }
        return list.ToArray();
    }

    public int[] GetInts()
    {
        List<int> list = new List<int>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is not IntValueGameStateBag intValueGameStateBag)
            {
                throw new Exception("Expected list of integers.");
            }
            list.Add(intValueGameStateBag.Value);
        }
        return list.ToArray();
    }

    public string[] GetStrings()
    {
        List<string> list = new List<string>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is not StringValueGameStateBag stringValueGameStateBag)
            {
                throw new Exception("Expected list of strings.");
            }
            list.Add(stringValueGameStateBag.Value);
        }
        return list.ToArray();
    }
    public string?[] GetNullableStrings()
    {
        List<string?> list = new List<string?>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is NullValueGameStateBag)
            {
                list.Add(null);
            }
            else
            {
                if (gameStateBag is not StringValueGameStateBag stringValueGameStateBag)
                {
                    throw new Exception("Expected list of strings.");
                }
                list.Add(stringValueGameStateBag.Value);
            }
        }
        return list.ToArray();
    }

    public string[][] GetArrayOfStrings()
    {
        List<string[]> listOfStrings = new List<string[]>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is not ListGameStateBag listOfStringsBag)
            {
                throw new Exception("Jagged array of string not a list.");
            }
            RestoreGameState restoreGameState = New(gameStateBag);
            string[] strings = restoreGameState.GetStrings();
            listOfStrings.Add(strings);
        }
        return listOfStrings.ToArray();
    }

    public byte[][] GetArrayOfBytes()
    {
        List<byte[]> listOfBytes = new List<byte[]>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is not ByteArrayGameStateBag byteArrayGameStateBag)
            {
                throw new KeyNotFoundException($"List was not of {nameof(ByteArrayGameStateBag)}.");
            }
            RestoreGameState restoreGameState = New(gameStateBag);
            listOfBytes.Add(restoreGameState.GetBytes());
        }
        return listOfBytes.ToArray();
    }

    public Dictionary<T1, T2> GetDictionary<T1, T2>(Func<RestoreGameState, T1> keySelector, Func<RestoreGameState, T2> valueSelector) where T1 : notnull
    {
        Dictionary<T1, T2> dictionary = new Dictionary<T1, T2>();
        ListGameStateBag listGameStateBag = (ListGameStateBag)GameStateBag;
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            DictionaryGameStateBag dictionaryGameStateBag = (DictionaryGameStateBag)gameStateBag;
            GameStateBag? keyGameStateBag = dictionaryGameStateBag.GetByKey("Key", 0);
            if (keyGameStateBag is null)
            {
                throw new KeyNotFoundException($"Key GameStateBag not found for dictionary entry.");
            }
            RestoreGameState restoreGameState = New(keyGameStateBag);
            T1 key = keySelector(restoreGameState);

            GameStateBag? valueGameStateBag = dictionaryGameStateBag.GetByKey("Value", 1);
            if (valueSelector is null)
            {
                throw new KeyNotFoundException($"Value GameStateBag not found for dictionary entry.");
            }
            restoreGameState = New(valueGameStateBag);
            T2 value = valueSelector(restoreGameState);
            dictionary.Add(key, value);
        }
        return dictionary;
    }
    public char[] GetChars() => ((CharArrayGameStateBag)GameStateBag).Value;
    public int GetInt() => ((IntValueGameStateBag)GameStateBag).Value;
    public ulong GetUlong() => ((UlongValueGameStateBag)GameStateBag).Value;
    public int? GetNullableInt()
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetInt();
    }

    public DateTime? GetNullableDateTime()
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetDateTime();
    }

    public string? GetStringOrDefault()
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetString(); // TODO: This smells
    }

    public bool? GetBoolOrDefault()
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetBool(); // TODO: This smells
    }

    public string GetString() => ((StringValueGameStateBag)GameStateBag).Value;

    public DateTime GetDateTime() => ((DateTimeValueGameStateBag)GameStateBag).Value;

    public byte GetByte() => ((ByteValueGameStateBag)GameStateBag).Value;

    public char GetChar() => ((CharValueGameStateBag)GameStateBag).Value;

    public decimal GetDecimal() => ((DecimalValueGameStateBag)GameStateBag).Value;

    public byte[] GetBytes() => ((ByteArrayGameStateBag)GameStateBag).Value;

    public TimeSpan GetTimeSpan() => ((TimeSpanValueGameStateBag)GameStateBag).Value;
}
