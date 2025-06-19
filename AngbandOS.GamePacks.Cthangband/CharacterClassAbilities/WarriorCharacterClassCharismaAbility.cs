namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
    public override int Bonus => -1;
}