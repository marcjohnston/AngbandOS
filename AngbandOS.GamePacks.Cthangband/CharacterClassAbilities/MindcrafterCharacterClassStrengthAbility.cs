namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindcrafterCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MindcrafterCharacterClass);
    public override int Bonus => -1;
}