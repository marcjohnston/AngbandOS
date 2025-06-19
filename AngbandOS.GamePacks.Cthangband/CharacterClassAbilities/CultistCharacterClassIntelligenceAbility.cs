namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultistCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.CultistCharacterClass);
    public override int Bonus => 4;
}