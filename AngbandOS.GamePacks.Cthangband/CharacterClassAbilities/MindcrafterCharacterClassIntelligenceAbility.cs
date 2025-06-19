namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindcrafterCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MindcrafterCharacterClass);
    public override int Bonus => 0;
}