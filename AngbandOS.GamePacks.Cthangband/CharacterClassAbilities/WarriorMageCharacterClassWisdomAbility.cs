namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorMageCharacterClass);
    public override int Bonus => 0;
}