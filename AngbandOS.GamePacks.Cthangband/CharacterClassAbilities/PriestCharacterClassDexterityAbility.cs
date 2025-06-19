namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PriestCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PriestCharacterClass);
    public override int Bonus => -1;
}