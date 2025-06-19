namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultistCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.CultistCharacterClass);
    public override int Bonus => -5;
}