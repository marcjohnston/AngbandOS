namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
    public override int Bonus => 2;
}