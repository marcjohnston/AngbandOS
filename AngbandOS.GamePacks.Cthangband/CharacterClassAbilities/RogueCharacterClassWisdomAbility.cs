namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
    public override int Bonus => -2;
}