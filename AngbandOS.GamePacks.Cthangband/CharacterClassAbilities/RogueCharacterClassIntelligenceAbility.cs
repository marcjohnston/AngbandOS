namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
    public override int Bonus => 1;
}