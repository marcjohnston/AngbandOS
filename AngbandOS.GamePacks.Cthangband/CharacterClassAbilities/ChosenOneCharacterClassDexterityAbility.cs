namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChosenOneCharacterClassDexterityAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChosenOneCharacterClass);
    public override int Bonus => 2;
}