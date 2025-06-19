namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MageCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override int Bonus => 1;
}