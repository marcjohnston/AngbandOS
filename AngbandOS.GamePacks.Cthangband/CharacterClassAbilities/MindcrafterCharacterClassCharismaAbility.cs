namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindcrafterCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MindcrafterCharacterClass);
    public override int Bonus => 2;
}