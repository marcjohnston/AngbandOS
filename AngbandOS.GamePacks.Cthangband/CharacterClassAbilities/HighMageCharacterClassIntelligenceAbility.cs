namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMageCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override int Bonus => 4;
}