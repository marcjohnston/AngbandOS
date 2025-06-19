namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonkCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MonkCharacterClass);
    public override int Bonus => 2;
}