namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PaladinCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private PaladinCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(PaladinCharacterClass);
    public override int Bonus => -3;
}