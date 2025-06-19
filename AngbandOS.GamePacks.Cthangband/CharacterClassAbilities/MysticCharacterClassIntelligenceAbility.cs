namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MysticCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MysticCharacterClass);
    public override int Bonus => -1;
}