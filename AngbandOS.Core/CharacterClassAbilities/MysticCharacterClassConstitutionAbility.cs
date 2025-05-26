namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MysticCharacterClassConstitutionAbility : CharacterClassAbility
{
    private MysticCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(MysticCharacterClass);
    public override int Bonus => 2;
}