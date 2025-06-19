namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorMageCharacterClass);
    public override int Bonus => 2;
}