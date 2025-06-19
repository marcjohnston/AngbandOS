namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RangerCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
    public override int Bonus => 2;
}