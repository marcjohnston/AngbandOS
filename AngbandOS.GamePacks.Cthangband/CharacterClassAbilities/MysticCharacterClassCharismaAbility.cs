namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MysticCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MysticCharacterClass);
    public override int Bonus => 0;
}