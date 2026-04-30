// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class RacePower : IGetKey, IScript, IToJson, IGameSerialize
{
    private Game Game { get; }
    public RacePower(Game game, RacePowerGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        ScriptBindingKey = gameConfiguration.ScriptBindingKey;
        RaceBindingKey = gameConfiguration.RaceBindingKey;
        CharacterClassBindingKey = gameConfiguration.CharacterClassBindingKey;
    }
    public GameStateBag? Serialize(SaveGameState saveGameState) => null;
    public static string GetCompositeKey(Race race, CharacterClass? characterClass) => GameConfiguration.GetCompositeKey(race.GetKey, characterClass?.GetKey, nameof(RacePowerGameConfiguration));
    public IScript Script { get; private set; }
    private string ScriptBindingKey { get; }
    public Race Race { get; private set; }
    private string RaceBindingKey { get; }
    public CharacterClass? CharacterClass { get; private set; }
    private string? CharacterClassBindingKey { get; } = null;

    public string Key { get; }
    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState)
    {
        Script = Game.SingletonRepository.Get<IScript>(ScriptBindingKey);
        Race = Game.SingletonRepository.Get<Race>(RaceBindingKey);
        CharacterClass = Game.SingletonRepository.GetNullable<CharacterClass>(CharacterClassBindingKey);
    }

    public string ToJson()
    {
        RacePowerGameConfiguration gameConfiguration = new()
        {
            ScriptBindingKey = ScriptBindingKey,
            RaceBindingKey = RaceBindingKey,
            CharacterClassBindingKey = CharacterClassBindingKey,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public void ExecuteScript()
    {
        Script.ExecuteScript();
    }
}
