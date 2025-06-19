namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PriestCharacterClassIntelligenceAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PriestCharacterClass);
    public override int Bonus => -3;
}