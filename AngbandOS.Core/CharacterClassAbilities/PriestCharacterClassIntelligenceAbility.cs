namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PriestCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private PriestCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(PriestCharacterClass);
    public override int Bonus => -3;
}