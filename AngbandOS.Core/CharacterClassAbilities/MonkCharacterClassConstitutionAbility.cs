namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MonkCharacterClassConstitutionAbility : CharacterClassAbility
{
    private MonkCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(MonkCharacterClass);
    public override int Bonus => 2;
}