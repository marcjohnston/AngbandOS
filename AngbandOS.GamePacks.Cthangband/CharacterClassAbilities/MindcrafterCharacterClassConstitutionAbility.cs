namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindcrafterCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MindcrafterCharacterClass);
    public override int Bonus => -1;
}