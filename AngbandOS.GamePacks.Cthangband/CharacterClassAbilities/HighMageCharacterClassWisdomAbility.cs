namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMageCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override int Bonus => 0;
}