namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FanaticCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
    public override int Bonus => 2;
}