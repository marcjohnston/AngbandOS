namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorMageCharacterClass);
    public override int Bonus => 1;
}