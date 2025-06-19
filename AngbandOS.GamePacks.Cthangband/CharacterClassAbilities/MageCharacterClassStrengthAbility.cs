namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MageCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override int Bonus => -5;
}