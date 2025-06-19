namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RangerCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
    public override int Bonus => 1;
}