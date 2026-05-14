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
    private Dictionary<int, ObjectGameStateBag> ObjectIdToObjectGameStateBagDictionary { get; }
    public GameStateBag GameStateBag { get; }
    public bool UnusedAndEmptyObjectsPruned { get; }

    /// <summary>
    /// Creates a clone of the RestoreGameState with a new game state bag.  Only the New method should utilize this constructor.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="objectIdToReferenceDictionary"></param>
    /// <param name="gameStateBag"></param>
    private RestoreGameState(Game game, Dictionary<int, object> objectIdToReferenceDictionary, Dictionary<int, ObjectGameStateBag> objectIdToObjectGameStateBagDictionary, GameStateBag gameStateBag, bool unusedAndEmptyObjectsArePruned)
    {
        Game = game;
        ObjectIdToReferenceDictionary = objectIdToReferenceDictionary;
        ObjectIdToObjectGameStateBagDictionary = objectIdToObjectGameStateBagDictionary;
        GameStateBag = gameStateBag;
        UnusedAndEmptyObjectsPruned = unusedAndEmptyObjectsArePruned;
    }

    /// <summary>
    /// Creates a new instance of the RestoreGameState class.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="gameStateBag"></param>
    public RestoreGameState(Game game, GameStateBag gameStateBag, bool unusedAndEmptyObjectsArePruned)
    {
        Game = game;
        ObjectIdToReferenceDictionary = new Dictionary<int, object>();
        ObjectIdToObjectGameStateBagDictionary = new Dictionary<int, ObjectGameStateBag>();
        GameStateBag = gameStateBag;

        // Retrieve the pruned objects value from the saved game state.
        UnusedAndEmptyObjectsPruned = unusedAndEmptyObjectsArePruned;
    }

    #region Packing Methods
    public bool PackAsBytes => true;
    public bool PackBoolsAsBits => true;
    public RestorePack Unpack(string key)
    {
        byte[] data = Convert.FromBase64String(GetGameStateBag<ByteArrayGameStateBag>(key).Value);
        return new RestorePack(this, data);
    }
    #endregion

    public void TrackObject(int objectId, object singleton)
    {
        // We are tracking the object for the first time.  We will add it to the dictionary.  It is possible that we are tracking a reference before we have the object game state bag, so we will allow the object game state bag to be null for now and update it later when we have it.
        ObjectIdToReferenceDictionary.Add(objectId, singleton);
    }

    public void TrackGameStateBag(int objectId, ObjectGameStateBag objectGameStateBag)
    {
        ObjectIdToObjectGameStateBagDictionary.Add(objectId, objectGameStateBag);
    }

    public object? TryGetObjectById(int objectId)
    {
        if (ObjectIdToReferenceDictionary.TryGetValue(objectId, out object? value))
        {
#if DEBUG
            if (value is null)
            {
                throw new Exception("Cannot be null.");
            }
#endif
            return value;
        }
        return null;
    }

    public object GetObjectById(int objectId)
    {
        return ObjectIdToReferenceDictionary[objectId];
    }

    public RestoreGameState New(GameStateBag gameStateBag)
    {
        return new RestoreGameState(Game, ObjectIdToReferenceDictionary, ObjectIdToObjectGameStateBagDictionary, gameStateBag, UnusedAndEmptyObjectsPruned);
    }

    public bool Verify(object? singleton)
    {
#if DEBUG
        return GameStateBag.Verify(this, singleton);
#else
        return true;
#endif
    }

    /// <summary>
    /// Retrieve the game state bag for a given singleton for the Bind phase.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    /// <remarks>
    /// The singletons will have already been created and tracked during the load phase.  So no additional tracking will be needed.
    /// </remarks>
    public RestoreGameState Get(string key)
    {
        if (GameStateBag is not ObjectGameStateBag singletonRepositoryGameStateBag)
        {
            throw new InvalidOperationException($"GameStateBag is not an {nameof(ObjectGameStateBag)}.");
        }

        // Retrieve the game state bag for the singleton by key.  We are not tracking the object id's with the singleton, so we need to repeat the lookup again.
        if (singletonRepositoryGameStateBag.TryGetGameStateBag(key, out GameStateBag? singletonGameStateBag))
        {
            // Check to see if it is an object game state bag.  If so, it means the singleton was not serialized by a previous singleton, which should be most of the cases.
            if (singletonGameStateBag is ObjectGameStateBag objectGameStateBag)
            {
                // The value is null.  We can return early with the null game state bag.  The object game state bag should also be in the dictionary, but we will not be using it.
                return New(objectGameStateBag);
            }

            // Check to see if it is a reference game state bag.  If so, then it was serialized by a previous singleton.
            if (singletonGameStateBag is ReferenceGameStateBag referenceGameStateBag)
            {
                // We will need to retrieve the game state bag from the earlier dictionary.  The game state bag should have been tracked during the load phase, so it should be in the dictionary.
                ObjectGameStateBag originalObjectGameStateBag = ObjectIdToObjectGameStateBagDictionary[referenceGameStateBag.ObjectId];
                return New(originalObjectGameStateBag);
            }
            throw new Exception("Expected an ObjectGameStateBag or ReferenceGameStateBag.");
        }

        // The object doesn't exist.
        if (UnusedAndEmptyObjectsPruned)
        {
            return new RestoreGameState(Game, new NullValueGameStateBag(), UnusedAndEmptyObjectsPruned);
        }
        throw new Exception("Key not found in GameStateBag.");
    }

    public RestoreGameState GetByKey(string key)
    {
        if (GameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            if (objectGameStateBag.TryGetGameStateBag(key, out GameStateBag? gameStateBag))
            {
                return New(gameStateBag);
            }
            throw new KeyNotFoundException($"The key '{key}' was not found in the {nameof(ObjectGameStateBag)}.");
        }
        if (GameStateBag is DictionaryGameStateBag dictionaryGameStateBag)
        {
            if (dictionaryGameStateBag.Values.TryGetValue(key, out GameStateBag? gameStateBag))
            {
                return New(gameStateBag);
            }
            throw new KeyNotFoundException($"The key '{key}' was not found in the {nameof(DictionaryGameStateBag)}.");
        }
        throw new InvalidOperationException($"GameStateBag is not of type {nameof(ObjectGameStateBag)} or {nameof(DictionaryGameStateBag)}.");
    }
    public TGameStateBag GetGameStateBag<TGameStateBag>(string key) where TGameStateBag : GameStateBag
    {
        if (GameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            if (objectGameStateBag.TryGetGameStateBag(key, out var gameStateBag) && gameStateBag is TGameStateBag typedGameStateBag)
            {
                return typedGameStateBag;
            }
            throw new KeyNotFoundException($"The key '{key}' was not found in the {nameof(ObjectGameStateBag)}.");
        }
        if (GameStateBag is DictionaryGameStateBag dictionaryGameStateBag)
        {
            if (dictionaryGameStateBag.Values.TryGetValue(key, out var gameStateBag) && gameStateBag is TGameStateBag typedGameStateBag)
            {
                return typedGameStateBag;
            }
            throw new KeyNotFoundException($"The key '{key}' was not found in the {nameof(DictionaryGameStateBag)}.");
        }
        throw new InvalidOperationException($"GameStateBag is not of type {nameof(ObjectGameStateBag)} or {nameof(DictionaryGameStateBag)}.");
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

    public T? GetReferenceOrDefault<T>()
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetReference<T>();
    }

    public T[]? GetReferencesOrNull<T>()
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetReferences<T>(); // TODO: This smells
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

    public T?[] GetNullableReferences<T>()
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
                T t = restoreGameState.GetReference<T>();
                list.Add(t);
            }
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
            byte[] bytes = Convert.FromBase64String(byteArrayGameStateBag.Value);
            listOfBytes.Add(bytes);
        }
        return listOfBytes.ToArray();
    }

    public bool[][] GetArrayOfBools()
    {
        List<bool[]> listOfBools = new List<bool[]>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is not ListGameStateBag listOfStringsBag)
            {
                throw new Exception("Jagged array of string not a list.");
            }
            RestoreGameState restoreGameState = New(gameStateBag);
            bool[] bools = restoreGameState.GetBools();
            listOfBools.Add(bools);
        }
        return listOfBools.ToArray();
    }

    public char[] GetChars() => ((CharArrayGameStateBag)GameStateBag).Value.ToCharArray();
    public int GetInt(string key) => GetGameStateBag<IntValueGameStateBag>(key).Value;
    public int GetInt() => ((IntValueGameStateBag)GameStateBag).Value;
    public int? GetNullableInt(string key)
    {
        GameStateBag gameStateBag = GetGameStateBag<GameStateBag>(key);
        if (gameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetInt(key);
    }

    public DateTime? GetNullableDateTime(string key)
    {
        GameStateBag gameStateBag = GetGameStateBag<GameStateBag>(key);
        if (gameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetDateTime(key);
    }

    public T[][] GetArrayOfReferences<T>()
    {
        List<T[]> listOfReferences = new List<T[]>();
        foreach (GameStateBag gameStateBag in ((ListGameStateBag)GameStateBag).Values)
        {
            if (gameStateBag is not ListGameStateBag listOfStringsBag)
            {
                throw new Exception($"Jagged array of {typeof(T).Name} not a list.");
            }
            RestoreGameState referencesRestoreGameState = New(gameStateBag);
            T[] references = referencesRestoreGameState.GetReferences<T>();
            listOfReferences.Add(references);
        }
        return listOfReferences.ToArray();
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

    public DateTime GetDateTime(string key) => GetGameStateBag<DateTimeValueGameStateBag>(key).Value;

    public byte GetByte(string key) => GetGameStateBag<ByteValueGameStateBag>(key).Value;

    public char GetChar(string key) => GetGameStateBag<CharValueGameStateBag>(key).Value;

    public decimal GetDecimal(string key) => GetGameStateBag<DecimalValueGameStateBag>(key).Value;

    public char[] GetCharArray(string key) => GetGameStateBag<CharArrayGameStateBag>(key).Value.ToCharArray();

    public byte[] GetByteArray(string key) => Convert.FromBase64String(GetGameStateBag<ByteArrayGameStateBag>(key).Value);

    public TimeSpan GetTimeSpan(string key) => GetGameStateBag<TimeSpanValueGameStateBag>(key).Value;

    public string[] GetQueueStrings(string key) => GetGameStateBag<QueueOfStringGameStateBag>(key).Values.ToArray();
}
