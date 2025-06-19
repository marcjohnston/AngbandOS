namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RangerCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.RangerCharacterClass);
    public override int Bonus => 1;
}