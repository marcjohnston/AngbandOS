namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MageCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override int Bonus => 0;
}