// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Reflection;
using System.Text;

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

    /// <summary>
    /// Creates a clone of the RestoreGameState with a new game state bag.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="objectIdToReferenceDictionary"></param>
    /// <param name="gameStateBag"></param>
    private RestoreGameState(Game game, Dictionary<int, object> objectIdToReferenceDictionary, Dictionary<int, ObjectGameStateBag> objectIdToObjectGameStateBagDictionary, GameStateBag gameStateBag)
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
        ObjectIdToObjectGameStateBagDictionary = new Dictionary<int, ObjectGameStateBag>();
        GameStateBag = gameStateBag;
    }

    public bool ContainsKey(int key)
    {
        return ObjectIdToReferenceDictionary.ContainsKey(key);
    }

    public void TrackObject(int objectId, object singleton)
    {
        // We are tracking the object for the first time.  We will add it to the dictionary.  It is possible that we are tracking a reference before we have the object game state bag, so we will allow the object game state bag to be null for now and update it later when we have it.
        ObjectIdToReferenceDictionary.Add(objectId, singleton);
    }

    private void TrackGameStateBag(int objectId, ObjectGameStateBag objectGameStateBag)
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
        return GameStateBag.Verify(this, singleton);
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
        #if DEBUG
        if (GameStateBag is not ObjectGameStateBag singletonRepositoryGameStateBag)
        {
            throw new InvalidOperationException($"GameStateBag is not an {nameof(ObjectGameStateBag)}.");
        }
        #endif

        // Retrieve the game state bag for the singleton by key.  We are not tracking the object id's with the singleton, so we need to repeat the lookup again.
        if (singletonRepositoryGameStateBag.Values.TryGetValue(key, out GameStateBag? singletonGameStateBag))
        {
            // Check to see if it is an object game state bag.  If so, it means the singleton was not serialized by a previous singleton, which should be most of the cases.
            if (singletonGameStateBag is ObjectGameStateBag objectGameStateBag)
            {
                // The value is null.  We can return early with the null game state bag.  The object game state bag should also be in the dictionary, but we will not be using it.
                return new RestoreGameState(Game, ObjectIdToReferenceDictionary, ObjectIdToObjectGameStateBagDictionary, objectGameStateBag);
            }

            // Check to see if it is a reference game state bag.  If so, then it was serialized by a previous singleton.
            if (singletonGameStateBag is ReferenceGameStateBag referenceGameStateBag)
            {
                // We will need to retrieve the game state bag from the earlier dictionary.  The game state bag should have been tracked during the load phase, so it should be in the dictionary.
                ObjectGameStateBag originalObjectGameStateBag = ObjectIdToObjectGameStateBagDictionary[referenceGameStateBag.ObjectId];
                return new RestoreGameState(Game, ObjectIdToReferenceDictionary, ObjectIdToObjectGameStateBagDictionary, originalObjectGameStateBag);
            }
            throw new Exception("Expected an ObjectGameStateBag or ReferenceGameStateBag.");
        }

        // The object doesn't exist.
        throw new Exception("Key not found in GameStateBag.");
    }

    public TGameStateBag GetGameStateBag<TGameStateBag>(string key) where TGameStateBag : GameStateBag
    {
        if (GameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            if (objectGameStateBag.Values.TryGetValue(key, out var gameStateBag) && gameStateBag is TGameStateBag typedGameStateBag)
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

    public bool GetBool(string key) => GetGameStateBag<BoolValueGameStateBag>(key).Value;

    public T GetEnum<T>(string key) where T : Enum
    {
        int value = GetInt(key);
        if (Enum.IsDefined(typeof(T), value))
        {
            return (T)(object)value;
        }
        throw new ArgumentOutOfRangeException(nameof(value), $"Invalid value for enum {typeof(T).Name}: {value}");
    }

    public T[] GetEnums<T>(string key) where T : Enum
    {
        ListGameStateBag listGameStateBag = GetGameStateBag<ListGameStateBag>(key);
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

    public bool[] GetBools(string key)
    {
        ListGameStateBag listGameStateBag = GetGameStateBag<ListGameStateBag>(key);
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

    private T GetReference<T>(GameStateBag gameStateBag)
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
        if (gameStateBag is ReferenceGameStateBag referenceGameStateBag)
        {
            // This is a reference game state bag.  Retrieve the object id and check to see if the object is already being tracked.
            int objectId = referenceGameStateBag.ObjectId;
            if (ObjectIdToReferenceDictionary.TryGetValue(objectId, out object? singleton))
            {
                if (!typeof(T).IsAssignableFrom(singleton.GetType()))
                {
                    throw new InvalidOperationException($"Reference is not of type {typeof(T).Name}.");
                }

                // We need to track the object.  Since this is a reference game state bag, we do not have the object game state bag yet and will pass null.
                T typedReference = (T)singleton;
                return typedReference;
            }
            throw new Exception("Reference ID not found in ObjectIdToReferenceDictionary.");
        }
        else if (gameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            // This is an object game state bag.  The object might already exist.  If it does, we can return it but we might need to add the object game state bag to the reference tracking for the bind phase.
            int objectId = objectGameStateBag.ObjectId;
            if (ObjectIdToReferenceDictionary.TryGetValue(objectId, out object? singleton))
            {
                // The object already exists, even though we now have the object game state bag.  We will need to track this object game state bag for the bind phase.
                if (!typeof(T).IsAssignableFrom(singleton.GetType()))
                {
                    throw new InvalidOperationException($"Reference is not of type {typeof(T).Name}.");
                }
                T typedReference = (T)singleton;
                TrackGameStateBag(objectId, objectGameStateBag);
                return typedReference;
            }

            // The object doesn't exist yet.  We need to create it and track it.
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
        throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name} or {typeof(ReferenceGameStateBag).Name}.");
    }

    public T GetReference<T>(string key)
    {
        if (GameStateBag is not ObjectGameStateBag objectGameStateBag)
        {
            throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name}.");
        }
        if (objectGameStateBag.Values.TryGetValue(key, out GameStateBag? gameStateBag))
        {
            return GetReference<T>(gameStateBag);
        }
        throw new KeyNotFoundException($"The key '{key}' was not found in the GameStateBag.");
    }


    public T? GetReferenceOrDefault<T>(string key)
    {
        if (GameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            if (objectGameStateBag.Values.TryGetValue(key, out GameStateBag? gameStateBag))
            {
                if (gameStateBag is NullValueGameStateBag)
                {
                    return default;
                }
                return GetReference<T>(gameStateBag);
            }
        }
        if (GameStateBag is DictionaryGameStateBag dictionaryGameStateBag)
        {
            if (dictionaryGameStateBag.Values.TryGetValue(key, out GameStateBag? gameStateBag))
            {
                if (gameStateBag is NullValueGameStateBag)
                {
                    return default;
                }
                return GetReference<T>(gameStateBag);
            }
        }
        throw new InvalidOperationException($"GameStateBag is not of type {nameof(ObjectGameStateBag)} or {nameof(DictionaryGameStateBag)}.");
    }

    public T[]? GetReferencesOrNull<T>(string key)
    {
        if (GameStateBag is not ObjectGameStateBag objectGameStateBag)
        {
            throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name}.");
        }
        if (objectGameStateBag.Values.TryGetValue(key, out GameStateBag? gameStateBag))
        {
            if (gameStateBag is NullValueGameStateBag)
            {
                return default;
            }
            return GetReferences<T>(key); // TODO: This smells
        }
        throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name}.");
    }

    public T[] GetReferences<T>(string key)
    {
        List<T> list = new List<T>();
        foreach (GameStateBag gameStateBag in GetGameStateBag<ListGameStateBag>(key).Values)
        {
            T t = GetReference<T>(gameStateBag);
            list.Add(t);
        }
        return list.ToArray();
    }

    public T?[] GetNullableReferences<T>(string key)
    {
        List<T?> list = new List<T?>();
        foreach (GameStateBag gameStateBag in GetGameStateBag<ListGameStateBag>(key).Values)
        {
            if (gameStateBag is NullValueGameStateBag)
            {
                list.Add(default);
            }
            else
            {
                list.Add(GetReference<T>(gameStateBag));
            }
        }
        return list.ToArray();
    }

    public int[] GetInts(string key)
    {
        ListGameStateBag listGameStateBag = GetGameStateBag<ListGameStateBag>(key);
        List<int> list = new List<int>();
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            if (gameStateBag is not IntValueGameStateBag intValueGameStateBag)
            {
                throw new Exception("Expected list of integers.");
            }
            list.Add(intValueGameStateBag.Value);
        }
        return list.ToArray();
    }

    public string[] GetStrings(string key)
    {
        ListGameStateBag listGameStateBag = GetGameStateBag<ListGameStateBag>(key);
        List<string> list = new List<string>();
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            if (gameStateBag is not StringValueGameStateBag stringValueGameStateBag)
            {
                throw new Exception("Expected list of strings.");
            }
            list.Add(stringValueGameStateBag.Value);
        }
        return list.ToArray();
    }
    public string[][] GetArrayOfStrings(string key)
    {
        ListGameStateBag listGameStateBag = GetGameStateBag<ListGameStateBag>(key);
        List<string[]> listOfStrings = new List<string[]>();
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            if (gameStateBag is not ListGameStateBag listOfStringsBag)
            {
                throw new Exception("Jagged array of string not a list.");
            }
            List<string> list = new List<string>();
            foreach (GameStateBag innerGameStateBag in listOfStringsBag.Values)
            {
                if (innerGameStateBag is not StringValueGameStateBag stringValueGameStateBag)
                {
                    throw new Exception("Expected inner list of strings.");
                }
                list.Add(stringValueGameStateBag.Value);
            }
            listOfStrings.Add(list.ToArray());
        }
        return listOfStrings.ToArray();
    }

    public byte[][] GetArrayOfBytes(string key)
    {
        ListGameStateBag listGameStateBag = GetGameStateBag<ListGameStateBag>(key);
        List<byte[]> listOfBytes = new List<byte[]>();
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            if (gameStateBag is not ByteArrayGameStateBag byteArrayGameStateBag)
            {
                throw new KeyNotFoundException($"List was not of {nameof(ByteArrayGameStateBag)}.");
            }
            byte[] bytes = Encoding.UTF8.GetBytes(byteArrayGameStateBag.Value);
            listOfBytes.Add(bytes);
        }
        return listOfBytes.ToArray();
    }

    public bool[][] GetArrayOfBools(string key)
    {
        ListGameStateBag listGameStateBag = GetGameStateBag<ListGameStateBag>(key);
        List<bool[]> listOfBools = new List<bool[]>();
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            if (gameStateBag is not ListGameStateBag listOfStringsBag)
            {
                throw new Exception("Jagged array of string not a list.");
            }
            List<bool> list = new List<bool>();
            foreach (GameStateBag innerGameStateBag in listOfStringsBag.Values)
            {
                if (innerGameStateBag is not BoolValueGameStateBag boolValueGameStateBag)
                {
                    throw new Exception("Expected inner list of strings.");
                }
                list.Add(boolValueGameStateBag.Value);
            }
            listOfBools.Add(list.ToArray());
        }
        return listOfBools.ToArray();
    }

    public char[] GetChars(string key) => GetGameStateBag<CharArrayGameStateBag>(key).Value.ToCharArray();
    public int GetInt(string key) => GetGameStateBag<IntValueGameStateBag>(key).Value;
    public int? GetNullableInt(string key)
    {
        GameStateBag gameStateBag = GetGameStateBag<GameStateBag>(key);
        if (gameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetInt(key);
    }

    public bool? GetNullableBool(string key)
    {
        GameStateBag gameStateBag = GetGameStateBag<GameStateBag>(key);
        if (gameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetBool(key);
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

    public T[][] GetJaggedArrayOfReferences<T>(string key)
    {
        ListGameStateBag listGameStateBag = GetGameStateBag<ListGameStateBag>(key);
        List<T[]> listOfStrings = new List<T[]>();
        foreach (GameStateBag gameStateBag in listGameStateBag.Values)
        {
            if (gameStateBag is not ListGameStateBag listOfStringsBag)
            {
                throw new Exception($"Jagged array of {typeof(T).Name} not a list.");
            }

            List<T> list = new List<T>();
            foreach (GameStateBag innerGameStateBag in listOfStringsBag.Values)
            {
                list.Add(GetReference<T>(innerGameStateBag));
            }
            listOfStrings.Add(list.ToArray());
        }
        return listOfStrings.ToArray();
    }

    public string? GetStringOrDefault(string key)
    {
        GameStateBag gameStateBag = GetGameStateBag<GameStateBag>(key);
        if (gameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetString(key); // TODO: This smells
    }

    public bool? GetBoolOrDefault(string key)
    {
        GameStateBag gameStateBag = GetGameStateBag<GameStateBag>(key);
        if (gameStateBag is NullValueGameStateBag)
        {
            return default;
        }
        return GetBool(key); // TODO: This smells
    }

    public string GetString(string key) => GetGameStateBag<StringValueGameStateBag>(key).Value;

    public DateTime GetDateTime(string key) => GetGameStateBag<DateTimeValueGameStateBag>(key).Value;

    public byte GetByte(string key) => GetGameStateBag<ByteValueGameStateBag>(key).Value;

    public char GetChar(string key) => GetGameStateBag<CharValueGameStateBag>(key).Value;

    public decimal GetDecimal(string key) => GetGameStateBag<DecimalValueGameStateBag>(key).Value;

    public char[] GetCharArray(string key) => GetGameStateBag<CharArrayGameStateBag>(key).Value.ToCharArray();

    public byte[] GetByteArray(string key) => Encoding.UTF8.GetBytes(GetGameStateBag<ByteArrayGameStateBag>(key).Value);

    public TimeSpan GetTimeSpan(string key) => GetGameStateBag<TimeSpanValueGameStateBag>(key).Value;

    public string[] GetQueueStrings(string key) => GetGameStateBag<QueueOfStringGameStateBag>(key).Values.ToArray();
}
