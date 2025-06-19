namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMageCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override int Bonus => 0;
}