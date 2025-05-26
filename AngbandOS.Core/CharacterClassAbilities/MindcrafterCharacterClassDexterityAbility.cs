namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MindcrafterCharacterClassDexterityAbility : CharacterClassAbility
{
    private MindcrafterCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(MindcrafterCharacterClass);
    public override int Bonus => -1;
}