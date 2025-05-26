namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MageCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private MageCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(MageCharacterClass);
    public override int Bonus => 3;
}