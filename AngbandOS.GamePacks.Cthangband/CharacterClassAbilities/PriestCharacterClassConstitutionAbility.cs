namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PriestCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PriestCharacterClass);
    public override int Bonus => 0;
}