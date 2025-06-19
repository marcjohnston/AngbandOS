namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonkCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MonkCharacterClass);
    public override int Bonus => 1;
}