// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;
    
internal class DictionaryGameStateBag : GameStateBag
{
    public Dictionary<string, GameStateBag> Values { get; }
    public DictionaryGameStateBag(GameStateBag? gameStateBag, params (string Key, GameStateBag GameState)[] values)
    {
        Values = new Dictionary<string, GameStateBag>();
        if (gameStateBag is DictionaryGameStateBag dictionaryGameStateBag)
        {
            foreach ((string Key, GameStateBag GameState) in dictionaryGameStateBag.Values)
            {
                Values.Add(Key, GameState);
            }
        }
        else if (gameStateBag is not null)
        {
            throw new Exception("Invalid game state bag provided to the constructor of a DictionaryGameStateBag.  The game state bag must be null or a DictionaryGameStateBag.");
        }
        foreach ((string Key, GameStateBag GameState) value in values)
        {
            Values.Add(value.Key, value.GameState);
        }
    }
    public DictionaryGameStateBag(params (string Key, GameStateBag GameState)[] values)
    {
        Values = values.ToDictionary(_value => _value.Key, _value => _value.GameState);
    }
    public DictionaryGameStateBag(Dictionary<string, GameStateBag> value)
    {
        Values = value;
    }
    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        return true;
        throw new NotImplementedException();
    }
}