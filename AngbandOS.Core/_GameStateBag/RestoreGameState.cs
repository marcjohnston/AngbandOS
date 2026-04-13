// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text;

namespace AngbandOS.Core;

/// <summary>
/// Represents the object for restoring game state values.  It keeps a reference to the dictionary used to track object creation. 
/// </summary>
internal class RestoreGameState
{
    private Game Game { get; }
    private Dictionary<int, IGetKey> ObjectIdToReferenceDictionary { get; }
    public GameStateBag GameStateBag { get; }
    public RestoreGameState(Game game, Dictionary<int, IGetKey> objectIdToReferenceDictionary, GameStateBag gameStateBag)
    {
        Game = game;
        ObjectIdToReferenceDictionary = objectIdToReferenceDictionary;
        GameStateBag = gameStateBag;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="singleton"></param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <remarks>
    /// Objects registration can occur via objects or references.  The order depends on how the serialization unfolded.
    /// </remarks>
    public void RegisterSingleton(IGetKey singleton)
    {
        if (GameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            ObjectIdToReferenceDictionary[objectGameStateBag.ObjectId] = singleton;
        }
        else if (GameStateBag is ReferenceGameStateBag referenceGameStateBag)
        {
            ObjectIdToReferenceDictionary[referenceGameStateBag.ObjectId] = singleton;
        }
        else
        {
            throw new InvalidOperationException($"GameStateBag is not a {typeof(ObjectGameStateBag)}.");
        }
    }
    public IGetKey GetObjectById(int objectId)
    {
        return ObjectIdToReferenceDictionary[objectId];
    }

    public RestoreGameState New(GameStateBag gameStateBag)
    {
        return new RestoreGameState(Game, ObjectIdToReferenceDictionary, gameStateBag);
    }

    public bool Verify(object? singleton)
    {
        return GameStateBag.Verify(this, singleton);
    }

    public RestoreGameState? Get(string key)
    {
        if (GameStateBag is not DictionaryGameStateBag dictionaryGameStateBag)
        {
            throw new InvalidOperationException("GameStateBag is not a DictionaryGameStateBag.");
        }

        if (dictionaryGameStateBag.Values.TryGetValue(key, out GameStateBag? gameStateBag))
        {
            return new RestoreGameState(Game, ObjectIdToReferenceDictionary, gameStateBag);
        }
        return null;
    }

    private TGameStateBag GetGameStateBag<TGameStateBag>(string key) where TGameStateBag : GameStateBag
    {
        if (GameStateBag is not ObjectGameStateBag objectGameStateBag)
        {
            throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name}.");
        }
        if (objectGameStateBag.Values.TryGetValue(key, out var gameStateBag) && gameStateBag is TGameStateBag typedGameStateBag)
        {
            return typedGameStateBag;
        }
        throw new KeyNotFoundException($"The key '{key}' was not found in the GameStateBag or is not of type {typeof(TGameStateBag).Name}.");
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

    public bool[] GetArrayOfBool(string key)
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

    public T GetReference<T>(GameStateBag gameStateBag)
    {
        if (gameStateBag is ReferenceGameStateBag referenceGameStateBag)
        {
            if (ObjectIdToReferenceDictionary.TryGetValue(referenceGameStateBag.ObjectId, out var reference))
            {
                if (reference is not T typedReference)
                {
                    throw new InvalidOperationException($"Reference is not of type {typeof(T).Name}.");
                }
                return typedReference;
            }
            throw new Exception("Reference ID not found in ObjectIdToReferenceDictionary.");
        }
        else if (gameStateBag is ObjectGameStateBag objectGameStateBag)
        {
            if (ObjectIdToReferenceDictionary.TryGetValue(objectGameStateBag.ObjectId, out var reference))
            {
                if (reference is not T typedReference)
                {
                    throw new InvalidOperationException($"Reference is not of type {typeof(T).Name}.");
                }
                return typedReference;
            }
            // The object doesn't exist yet.  We need to create it.
            var fullyQualifiedName = $"{typeof(Game).Assembly.GetName().Name}.Core.{objectGameStateBag.TypeName}";
            Type? type = Type.GetType(fullyQualifiedName);
            if (type is null)
            {
                throw new Exception($"{fullyQualifiedName} type not found.  Ensure it is in the Core namespace.");
            }
            object?[] parameters = new object?[] { Game, New(objectGameStateBag) };
            T? t = (T?)Activator.CreateInstance(type, parameters);
            if (t is null)
            {
                throw new Exception($"Unable to instantiate a new {objectGameStateBag.TypeName}.");
            }
            return t;
        }
        throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name} or {typeof(ReferenceGameStateBag).Name}.");
    }

    public T GetReference<T>(string key)
    {
        if (GameStateBag is not ObjectGameStateBag thisObjectGameStateBag)
        {
            throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name}.");
        }
        if (thisObjectGameStateBag.Values.TryGetValue(key, out GameStateBag? gameStateBag))
        {
            return GetReference<T>(gameStateBag);
        }
        throw new KeyNotFoundException($"The key '{key}' was not found in the GameStateBag.");
    }


    public T? GetNullableReference<T>(string key)
    {
        if (GameStateBag is not ObjectGameStateBag thisObjectGameStateBag)
        {
            throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name}.");
        }
        if (thisObjectGameStateBag.Values.TryGetValue(key, out GameStateBag? gameStateBag))
        {
            if (gameStateBag is NullValueGameStateBag)
            {
                return default;
            }
            return GetReference<T>(gameStateBag);
        }
        throw new InvalidOperationException($"GameStateBag is not of type {typeof(ObjectGameStateBag).Name} or {typeof(ReferenceGameStateBag).Name}.");
    }

    public int GetInt(string key) => GetGameStateBag<IntValueGameStateBag>(key).Value;
    public int? GetNullableInt(string key)
    {
        if (GameStateBag is NullValueGameStateBag)
        {
            return null;
        }
        return GetInt(key);
    }

    public string GetString(string key) => GetGameStateBag<StringValueGameStateBag>(key).Value;

    public DateTime GetDateTime(string key) => GetGameStateBag<DateTimeValueGameStateBag>(key).Value;

    public byte GetByte(string key) => GetGameStateBag<ByteValueGameStateBag>(key).Value;

    public char GetChar(string key) => GetGameStateBag<CharValueGameStateBag>(key).Value;

    public decimal GetDecimal(string key) => GetGameStateBag<DecimalValueGameStateBag>(key).Value;

    public char[] GetCharArray(string key) => GetGameStateBag<CharArrayGameStateBag>(key).Value.ToCharArray();

    public byte[] GetByteArray(string key) => Encoding.UTF8.GetBytes(GetGameStateBag<ByteArrayGameStateBag>(key).Value);

    public TimeSpan GetTimeSpan(string key) => GetGameStateBag<TimeSpanValueGameStateBag>(key).Value;

    //public ColorEnum GetColorEnum(string key) => GetGameStateBag<ColorEnumValueGameStateBag>(key).Value;

    public string[] GetQueueStrings(string key) => GetGameStateBag<QueueOfStringGameStateBag>(key).Values.ToArray();
    public bool IsEmpty()
    {
        switch (GameStateBag)
        {
            case ObjectGameStateBag objectGameStateBag:
                return objectGameStateBag.Values.Count == 0;
            case DictionaryGameStateBag dictionaryGameStateBag:
                return dictionaryGameStateBag.Values.Count == 0;
            default:
                return false; // Primitive types are never empty.
        }
    }
}
