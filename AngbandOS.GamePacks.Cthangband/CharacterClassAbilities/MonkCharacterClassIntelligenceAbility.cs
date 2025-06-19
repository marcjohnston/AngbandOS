namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonkCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MonkCharacterClass);
    public override int Bonus => -1;
}