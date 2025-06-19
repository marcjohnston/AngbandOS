namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChannelerCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChannelerCharacterClass);
    public override int Bonus => -1;
}