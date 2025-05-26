namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class FanaticCharacterClassConstitutionAbility : CharacterClassAbility
{
    private FanaticCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(FanaticCharacterClass);
    public override int Bonus => 2;
}