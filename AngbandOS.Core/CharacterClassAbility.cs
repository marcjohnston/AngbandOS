namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class CharacterClassAbility : IGetKey, IToJson
{
    protected readonly Game Game;
    public CharacterClassAbility(Game game, CharacterClassAbilityGameConfiguration characterClassAbilityGameConfiguration)
    {
        Game = game;
        Bonus = characterClassAbilityGameConfiguration.Bonus;
        CharacterClassBindingKey = characterClassAbilityGameConfiguration.CharacterClassBindingKey;
        AbilityBindingKey = characterClassAbilityGameConfiguration.AbilityBindingKey;
   }
    public virtual int Bonus { get; } = 0;

    public BaseCharacterClass CharacterClass { get; private set; }
    public Ability Ability { get; private set; }
    public virtual string CharacterClassBindingKey { get; }
    public virtual string AbilityBindingKey { get; }
    public string GetKey => $"{CharacterClassBindingKey}-{AbilityBindingKey}";

    public static string GetCompositeKey(BaseCharacterClass characterClass, Ability ability) => $"{characterClass.Key}-{ability.Key}";
    public void Bind()
    {
        CharacterClass = Game.SingletonRepository.Get<BaseCharacterClass>(CharacterClassBindingKey);
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