namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class CultistCharacterClassConstitutionAbility : CharacterClassAbility
{
    private CultistCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CultistCharacterClass);
    public override int Bonus => -2;
}