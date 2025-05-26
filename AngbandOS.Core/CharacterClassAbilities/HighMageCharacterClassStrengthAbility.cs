namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class HighMageCharacterClassStrengthAbility : CharacterClassAbility
{
    private HighMageCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(HighMageCharacterClass);
    public override int Bonus => -5;
}