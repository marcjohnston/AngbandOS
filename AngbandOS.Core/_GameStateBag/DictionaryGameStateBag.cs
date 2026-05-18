// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Reflection;
using System.Text.Json.Serialization;

namespace AngbandOS.Core;
    
internal class DictionaryGameStateBag : GameStateBag
{
    public readonly bool SequentialRetrieval = true;
    public Dictionary<string, GameStateBag> Values { get; } = new Dictionary<string, GameStateBag>();

    /// <summary>
    /// Creates a new dictionary game state bag with enumerated properties.  This constructor is typically used for the singleton repository object.
    /// </summary>
    /// <param name="values"></param>
    [JsonConstructor]
    public DictionaryGameStateBag(Dictionary<string, GameStateBag> values)
    {
        LoadValues(values.Select(_keyValuePair => (_keyValuePair.Key, _keyValuePair.Value)).ToArray());
    }

    public DictionaryGameStateBag(Dictionary<string, GameStateBag> values, bool sequentialRetrieval)
    {
        SequentialRetrieval = sequentialRetrieval;
        LoadValues(values.Select(_keyValuePair => (_keyValuePair.Key, _keyValuePair.Value)).ToArray());
    }

    /// <summary>
    /// Creates a new dictionary game state bag with itemized properties to be serialized with no base properties.  This constructor is typically used for non-derived models and the singletons.
    /// </summary>
    /// <param name="values"></param>
    public DictionaryGameStateBag(params (string Key, GameStateBag GameState)[] values)
    {
        LoadValues(values);
    }

    /// <summary>
    /// Creates a new dictionary game state bag with itemized properties to be serialized and additional base properties.  This constructor is typically used for derived models.
    /// </summary>
    /// <param name="gameStateBag"></param>
    /// <param name="values"></param>
    /// <exception cref="Exception"></exception>
    public DictionaryGameStateBag(GameStateBag? gameStateBag, params (string Key, GameStateBag GameState)[] values)
    {
        if (gameStateBag is DictionaryGameStateBag dictionaryGameStateBag)
        {
            LoadValues(dictionaryGameStateBag.Values.Select(_keyValuePair => (_keyValuePair.Key, _keyValuePair.Value)).ToArray());
        }
        else if (gameStateBag is not null)
        {
            throw new Exception("Invalid game state bag provided to the constructor of a DictionaryGameStateBag.  The game state bag must be null or a DictionaryGameStateBag.");
        }
        LoadValues(values);
    }

    private void LoadValues((string Key, GameStateBag GameState)[] values)
    {
        foreach ((string Key, GameStateBag GameState) in values)
        {
            Values.Add(Key, GameState);
        }
    }

    public bool TryGetGameStateBag(string key, out GameStateBag? gameStateBag) => Values.TryGetValue(key, out gameStateBag);

    public GameStateBag? GetByKey(string key, int currentSequentialIndex, bool verifySequentialRetrieval)
    {
        if (SequentialRetrieval)
        {
            key = currentSequentialIndex.ToString();
        }

        if (Values.TryGetValue(key, out GameStateBag? gameStateBag))
        {
#if DEBUG
            if (verifySequentialRetrieval)
            {
                int ordinalIndex = Values.Keys.ToList().IndexOf(key);
                if (ordinalIndex != currentSequentialIndex)
                {
                    throw new Exception($"Sequential index retrieval for the {key} property failed verification.");
                }
            }
#endif
            return gameStateBag;
        }
        throw new KeyNotFoundException($"The key '{key}' was not found in the {nameof(DictionaryGameStateBag)}.");
    }

    private static MemberInfo? GetMemberInfo(Type type, string name)
    {
        const BindingFlags flags =
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.NonPublic;

        while (type != null)
        {
            // Check property
            var prop = type.GetProperty(name, flags);
            if (prop != null)
                return prop;

            // Check field
            var field = type.GetField(name, flags);
            if (field != null)
                return field;

            type = type.BaseType!;
        }

        return null;
    }

    private static object? GetMemberValue(MemberInfo member, object obj)
    {
        return member switch
        {
            PropertyInfo p => p.GetValue(obj),
            FieldInfo f => f.GetValue(obj),
            _ => throw new NotSupportedException($"Unsupported member type: {member.GetType().Name}")
        };
    }

    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is null)
        {
            throw new Exception($"During restore verification, a null singleton cannot verify as an object.");
        }

        if (Values is not null)
        {
            foreach ((string PropertyName, GameStateBag ExpectedValue) in Values)
            {
                // Retrieve the field info from the singleton.
                MemberInfo? singletonMemberInfo = GetMemberInfo(singleton.GetType(), PropertyName);
                if (singletonMemberInfo is null)
                {
                    throw new Exception($"During restore verification, the {PropertyName} property for the {singleton.GetType().Name} singleton could not be found.");
                }

                // Retrieve the actual value from the singleton.
                object? singletonFieldValue = GetMemberValue(singletonMemberInfo, singleton);
                if (!restoreGameState.New(ExpectedValue).Verify(singletonFieldValue))
                {
                    throw new Exception($"During restore verification, the {PropertyName} property of the {singleton.GetType().Name} singleton did not verify.  Expected {ExpectedValue}.");
                }
            }
        }
        return true;
    }
}