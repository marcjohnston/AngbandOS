namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PriestCharacterClassConstitutionAbility : CharacterClassAbility
{
    private PriestCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(PriestCharacterClass);
    public override int Bonus => 0;
}