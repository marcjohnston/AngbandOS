namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorMageCharacterClass);
    public override int Bonus => 1;
}