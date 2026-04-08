namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal sealed class CharacterClassAbility : IGetKey, IToJson, IGameSerialize
{
    private Game Game { get; }
    public CharacterClassAbility(Game game, CharacterClassAbilityGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        Bonus = gameConfiguration.Bonus;
        CharacterClassBindingKey = gameConfiguration.CharacterClassBindingKey;
        AbilityBindingKey = gameConfiguration.AbilityBindingKey;
   }
    public DictionaryGameStateBag? Serialize(SaveGameState saveGameState) => null;
    public string Key { get; }
    public string GetKey => Key;
    public int Bonus { get; } = 0;
    public CharacterClass CharacterClass { get; private set; }
    public Ability Ability { get; private set; }
    public string CharacterClassBindingKey { get; }
    public string AbilityBindingKey { get; }

    public static string GetCompositeKey(CharacterClass characterClass, Ability ability) => $"{characterClass.Key}-{ability.Key}";
    public void Bind(RestoreGameState? restoreGameState)
    {
        CharacterClass = Game.SingletonRepository.Get<CharacterClass>(CharacterClassBindingKey);
        Ability = Game.SingletonRepository.Get<Ability>(AbilityBindingKey);
    }

    public string ToJson()
    {
        CharacterClassAbilityGameConfiguration gameConfiguration = new()
        {
            Bonus = Bonus,
            CharacterClassBindingKey = CharacterClassBindingKey,
            AbilityBindingKey = AbilityBindingKey,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
}