namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RangerCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
    public override int Bonus => 1;
}