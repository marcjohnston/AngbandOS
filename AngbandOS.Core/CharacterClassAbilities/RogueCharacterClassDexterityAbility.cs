namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RogueCharacterClassDexterityAbility : CharacterClassAbility
{
    private RogueCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(RogueCharacterClass);
    public override int Bonus => 3;
}