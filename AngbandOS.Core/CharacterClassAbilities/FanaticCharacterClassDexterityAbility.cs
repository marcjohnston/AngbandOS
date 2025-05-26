namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class FanaticCharacterClassDexterityAbility : CharacterClassAbility
{
    private FanaticCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(FanaticCharacterClass);
    public override int Bonus => 1;
}