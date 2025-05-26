namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MageCharacterClassConstitutionAbility : CharacterClassAbility
{
    private MageCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(MageCharacterClass);
    public override int Bonus => -2;
}