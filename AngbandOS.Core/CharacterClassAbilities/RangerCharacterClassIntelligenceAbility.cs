namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RangerCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private RangerCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(RangerCharacterClass);
    public override int Bonus => 2;
}