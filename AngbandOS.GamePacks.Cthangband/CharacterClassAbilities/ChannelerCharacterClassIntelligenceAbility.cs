namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChannelerCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChannelerCharacterClass);
    public override int Bonus => 0;
}