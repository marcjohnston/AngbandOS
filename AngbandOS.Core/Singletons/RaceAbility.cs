// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class RaceAbility : IGetKey, IToJson, IGameSerialize
{
    private Game Game { get; }
    public RaceAbility(Game game, RaceAbilityGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        Bonus = gameConfiguration.Bonus;
        RaceBindingKey = gameConfiguration.RaceBindingKey;
        AbilityBindingKey = gameConfiguration.AbilityBindingKey;
    }
    public DictionaryGameStateBag? Serialize(SaveGameState saveGameState) => null;
    public int Bonus { get; } = 0;
    public Race Race { get; private set; }
    public Ability Ability { get; private set; }
    public string RaceBindingKey { get; }
    public string AbilityBindingKey { get; }
    public string Key { get; }
    public string GetKey => Key;

    public static string GetCompositeKey(Race race, Ability ability) => GameConfiguration.GetCompositeKey(race.GetKey, ability.GetKey);
    public void Bind(RestoreGameState? restoreGameState)
    {
        Race = Game.SingletonRepository.Get<Race>(RaceBindingKey);
        Ability = Game.SingletonRepository.Get<Ability>(AbilityBindingKey);
    }

    public string ToJson()
    {
        RaceAbilityGameConfiguration gameConfiguration = new()
        {
            Bonus = Bonus,
            RaceBindingKey = RaceBindingKey,
            AbilityBindingKey = AbilityBindingKey,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
}
