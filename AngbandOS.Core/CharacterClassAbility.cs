namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal abstract class CharacterClassAbility : IGetKey
{
    protected readonly Game Game;
    protected CharacterClassAbility(Game game)
    {
        Game = game;
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
        return "";
    }
}