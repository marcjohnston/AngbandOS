namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorMageCharacterClass);
    public override int Bonus => 2;
}