namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DruidCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.DruidCharacterClass);
    public override int Bonus => -3;
}