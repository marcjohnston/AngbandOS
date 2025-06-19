namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FanaticCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
    public override int Bonus => 1;
}