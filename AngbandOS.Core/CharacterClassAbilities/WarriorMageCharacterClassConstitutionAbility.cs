namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorMageCharacterClassConstitutionAbility : CharacterClassAbility
{
    private WarriorMageCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(WarriorMageCharacterClass);
    public override int Bonus => 0;
}