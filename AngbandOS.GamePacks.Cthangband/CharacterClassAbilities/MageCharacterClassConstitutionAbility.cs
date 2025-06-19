namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MageCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override int Bonus => -2;
}