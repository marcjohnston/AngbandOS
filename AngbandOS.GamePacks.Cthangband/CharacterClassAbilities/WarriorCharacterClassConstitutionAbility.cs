namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
    public override int Bonus => 2;
}