namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class DruidCharacterClassDexterityAbility : CharacterClassAbility
{
    private DruidCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(DruidCharacterClass);
    public override int Bonus => -2;
}