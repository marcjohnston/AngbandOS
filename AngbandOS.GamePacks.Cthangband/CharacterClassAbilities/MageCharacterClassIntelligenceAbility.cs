namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MageCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override int Bonus => 3;
}