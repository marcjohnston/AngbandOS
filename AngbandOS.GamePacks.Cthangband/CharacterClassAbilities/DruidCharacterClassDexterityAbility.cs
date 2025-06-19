namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DruidCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.DruidCharacterClass);
    public override int Bonus => -2;
}