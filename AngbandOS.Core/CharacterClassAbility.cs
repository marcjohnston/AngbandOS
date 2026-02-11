namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal sealed class CharacterClassAbility : IGetKey, IToJson
{
    private readonly Game Game;
    public CharacterClassAbility(Game game, CharacterClassAbilityGameConfiguration characterClassAbilityGameConfiguration)
    {
        Game = game;
        Bonus = characterClassAbilityGameConfiguration.Bonus;
        CharacterClassBindingKey = characterClassAbilityGameConfiguration.CharacterClassBindingKey;
        AbilityBindingKey = characterClassAbilityGameConfiguration.AbilityBindingKey;
   }
    public int Bonus { get; } = 0;

    public CharacterClass CharacterClass { get; private set; }
    public Ability Ability { get; private set; }
    public string CharacterClassBindingKey { get; }
    public string AbilityBindingKey { get; }
    public string GetKey => $"{CharacterClassBindingKey}-{AbilityBindingKey}";

    public static string GetCompositeKey(CharacterClass characterClass, Ability ability) => $"{characterClass.Key}-{ability.Key}";
    public void Bind()
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