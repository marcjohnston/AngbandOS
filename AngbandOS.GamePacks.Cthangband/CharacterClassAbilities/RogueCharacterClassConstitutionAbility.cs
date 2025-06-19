namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
    public override int Bonus => 1;
}