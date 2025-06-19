namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindcrafterCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MindcrafterCharacterClass);
    public override int Bonus => -1;
}