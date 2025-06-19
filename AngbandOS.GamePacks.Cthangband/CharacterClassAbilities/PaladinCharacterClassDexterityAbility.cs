namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PaladinCharacterClass);
    public override int Bonus => 0;
}