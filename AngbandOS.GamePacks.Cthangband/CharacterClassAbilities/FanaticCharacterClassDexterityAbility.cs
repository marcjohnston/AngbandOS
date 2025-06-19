namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FanaticCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
    public override int Bonus => 1;
}