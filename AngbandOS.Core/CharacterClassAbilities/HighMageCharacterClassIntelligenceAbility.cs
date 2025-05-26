namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class HighMageCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private HighMageCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(HighMageCharacterClass);
    public override int Bonus => 4;
}