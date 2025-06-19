namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChannelerCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChannelerCharacterClass);
    public override int Bonus => -1;
}