namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DruidCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.DruidCharacterClass);
    public override int Bonus => -1;
}