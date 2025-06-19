namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMageCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override int Bonus => 1;
}