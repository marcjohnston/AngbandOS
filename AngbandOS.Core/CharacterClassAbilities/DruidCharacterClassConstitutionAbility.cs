namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class DruidCharacterClassConstitutionAbility : CharacterClassAbility
{
    private DruidCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(DruidCharacterClass);
    public override int Bonus => 0;
}