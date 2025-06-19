namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChosenOneCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChosenOneCharacterClass);
    public override int Bonus => 2;
}