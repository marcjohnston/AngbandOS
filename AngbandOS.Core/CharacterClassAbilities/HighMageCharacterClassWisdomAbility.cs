namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class HighMageCharacterClassWisdomAbility : CharacterClassAbility
{
    private HighMageCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(HighMageCharacterClass);
    public override int Bonus => 0;
}