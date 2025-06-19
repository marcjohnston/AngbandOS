namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMageCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override int Bonus => -5;
}