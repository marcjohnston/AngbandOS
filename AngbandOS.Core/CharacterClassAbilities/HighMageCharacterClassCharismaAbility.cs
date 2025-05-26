namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class HighMageCharacterClassCharismaAbility : CharacterClassAbility
{
    private HighMageCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(HighMageCharacterClass);
    public override int Bonus => 1;
}