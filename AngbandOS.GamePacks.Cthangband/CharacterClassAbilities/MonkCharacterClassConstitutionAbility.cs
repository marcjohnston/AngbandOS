namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonkCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MonkCharacterClass);
    public override int Bonus => 2;
}