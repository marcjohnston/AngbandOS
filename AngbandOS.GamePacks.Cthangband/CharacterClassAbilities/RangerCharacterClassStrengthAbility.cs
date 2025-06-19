namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RangerCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
    public override int Bonus => 2;
}