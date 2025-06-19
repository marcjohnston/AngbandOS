namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChannelerCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChannelerCharacterClass);
    public override int Bonus => 2;
}