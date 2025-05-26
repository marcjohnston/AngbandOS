namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorCharacterClassConstitutionAbility : CharacterClassAbility
{
    private WarriorCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(WarriorCharacterClass);
    public override int Bonus => 2;
}