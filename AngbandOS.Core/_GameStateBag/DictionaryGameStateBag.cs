// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;
    
internal class DictionaryGameStateBag : GameStateBag
{
    public Dictionary<string, GameStateBag> Values { get; } = new Dictionary<string, GameStateBag>();

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

    /// <summary>
    /// Creates a new dictionary game state bag with itemized properties to be serialized with no base properties.  This constructor is typically used for non-derived models and the singletons.
    /// </summary>
    /// <param name="values"></param>
    public DictionaryGameStateBag(params (string Key, GameStateBag GameState)[] values)
    {
        LoadValues(values);
    }

    /// <summary>
    /// Creates a new dictionary game state bag with enumerated properties.  This constructor is typically used for the singleton repository object.
    /// </summary>
    /// <param name="value"></param>
    public DictionaryGameStateBag(Dictionary<string, GameStateBag> value)
    {
        LoadValues(value.Select(_keyValuePair => (_keyValuePair.Key, _keyValuePair.Value)).ToArray());
    }
    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        return true;
    }
}