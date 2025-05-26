namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MageCharacterClassStrengthAbility : CharacterClassAbility
{
    private MageCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(MageCharacterClass);
    public override int Bonus => -5;
}