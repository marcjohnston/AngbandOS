namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChannelerCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChannelerCharacterClass);
    public override int Bonus => -1;
}