namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DruidCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.DruidCharacterClass);
    public override int Bonus => 0;
}