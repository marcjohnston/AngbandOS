namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class DruidCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private DruidCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(DruidCharacterClass);
    public override int Bonus => -3;
}