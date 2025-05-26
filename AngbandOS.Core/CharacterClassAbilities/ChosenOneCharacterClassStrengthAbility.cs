namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChosenOneCharacterClassStrengthAbility : CharacterClassAbility
{
    private ChosenOneCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(ChosenOneCharacterClass);
    public override int Bonus => 3;
}