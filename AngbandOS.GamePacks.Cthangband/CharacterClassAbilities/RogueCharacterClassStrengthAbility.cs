namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
    public override int Bonus => 2;
}