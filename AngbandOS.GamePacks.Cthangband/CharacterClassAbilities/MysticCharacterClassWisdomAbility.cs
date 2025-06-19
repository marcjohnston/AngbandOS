namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MysticCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MysticCharacterClass);
    public override int Bonus => 2;
}