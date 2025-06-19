namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PaladinCharacterClass);
    public override int Bonus => -3;
}