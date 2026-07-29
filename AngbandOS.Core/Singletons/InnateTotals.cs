// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class InnateTotals : IGetKey, IGameSerialize, IToJson
{
    private Game Game { get; }
    public InnateTotals(Game game, InnateTotalsGameConfiguration gameConfiguration)
    {
        Game = game;   
        Key = gameConfiguration.GetKey;
        CharacterClassBindingKey = gameConfiguration.CharacterClassBindingKey;
        RaceBindingKey = gameConfiguration.RaceBindingKey;
        MaxInnates = gameConfiguration.MaxInnates;
    }
    public string Key { get; }
    public string GetKey => Key;
    public CharacterClass? CharacterClass { get; private set; }
    public Race? Race { get; private set; }
    public string? CharacterClassBindingKey { get; }
    public string? RaceBindingKey { get; }
    public int[] MaxInnates { get; }
    public int Rank { get; private set; }

    public void Bind(RestoreGameState? restoreGameState)
    {
        CharacterClass = Game.SingletonRepository.GetNullable<CharacterClass>(CharacterClassBindingKey);
        Race = Game.SingletonRepository.GetNullable<Race>(RaceBindingKey);
        Rank = (CharacterClass is null ? 0 : 1) + (Race is null ? 0 : 1);
    }

    public GameStateBag? Serialize(SaveGameState saveGameState) => null;

    public string ToJson()
    {
        throw new NotImplementedException();
    }
}
