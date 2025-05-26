namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PaladinCharacterClassConstitutionAbility : CharacterClassAbility
{
    private PaladinCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(PaladinCharacterClass);
    public override int Bonus => 2;
}