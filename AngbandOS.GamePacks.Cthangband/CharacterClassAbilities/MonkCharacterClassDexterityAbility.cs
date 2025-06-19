namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonkCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.MonkCharacterClass);
    public override int Bonus => 3;
}