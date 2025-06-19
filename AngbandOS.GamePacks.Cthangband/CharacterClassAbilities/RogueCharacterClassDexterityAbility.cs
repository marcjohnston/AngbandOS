namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
    public override int Bonus => 3;
}