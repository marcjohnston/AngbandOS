namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class DruidCharacterClassStrengthAbility : CharacterClassAbility
{
    private DruidCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(DruidCharacterClass);
    public override int Bonus => -1;
}