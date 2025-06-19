namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
    public override int Bonus => -2;
}