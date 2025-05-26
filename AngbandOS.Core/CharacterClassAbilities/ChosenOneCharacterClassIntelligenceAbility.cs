namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChosenOneCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private ChosenOneCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(ChosenOneCharacterClass);
    public override int Bonus => -2;
}