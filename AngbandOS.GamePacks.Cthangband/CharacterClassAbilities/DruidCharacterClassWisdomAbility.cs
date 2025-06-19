namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DruidCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.DruidCharacterClass);
    public override int Bonus => 4;
}