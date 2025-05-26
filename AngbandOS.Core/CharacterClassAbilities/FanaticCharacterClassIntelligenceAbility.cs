namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class FanaticCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private FanaticCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(FanaticCharacterClass);
    public override int Bonus => 1;
}