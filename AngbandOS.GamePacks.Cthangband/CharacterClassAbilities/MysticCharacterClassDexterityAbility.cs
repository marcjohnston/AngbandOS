namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MysticCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MysticCharacterClass);
    public override int Bonus => 2;
}