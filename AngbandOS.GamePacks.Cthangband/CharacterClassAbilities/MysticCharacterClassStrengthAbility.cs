namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MysticCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MysticCharacterClass);
    public override int Bonus => 2;
}