namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
    public override int Bonus => -2;
}