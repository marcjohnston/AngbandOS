// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class RacialPower : IGetKey, IScript
{
    protected readonly Game Game;
    public RacialPower(Game game, RacialPowerGameConfiguration racialPowerGameConfiguration)
    {
        Game = game;
        ScriptBindingKey = racialPowerGameConfiguration.ScriptBindingKey;
        RaceBindingKey = racialPowerGameConfiguration.RaceBindingKey;
        CharacterClassBindingKey = racialPowerGameConfiguration.CharacterClassBindingKey;
    }
    public static string GetCompositeKey(Race race, BaseCharacterClass? characterClass) => Game.GetCompositeKey(race.GetKey, characterClass?.GetKey, nameof(RacialPower));
    public IScript Script { get; private set; }
    protected virtual string ScriptBindingKey { get; }
    public Race Race { get; private set; }
    protected virtual string RaceBindingKey { get; }
    public BaseCharacterClass? CharacterClass { get; private set; }
    protected virtual string? CharacterClassBindingKey { get; } = null;

    public string GetKey => Game.GetCompositeKey(RaceBindingKey, CharacterClassBindingKey, nameof(RacialPower));

    public void Bind()
    {
        Script = Game.SingletonRepository.Get<IScript>(ScriptBindingKey);
        Race = Game.SingletonRepository.Get<Race>(RaceBindingKey);
        CharacterClass = Game.SingletonRepository.GetNullable<BaseCharacterClass>(CharacterClassBindingKey);
    }

    public string ToJson()
    {
        RacialPowerGameConfiguration gameConfiguration = new()
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
