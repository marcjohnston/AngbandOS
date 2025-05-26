namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChannelerCharacterClassDexterityAbility : CharacterClassAbility
{
    private ChannelerCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(ChannelerCharacterClass);
    public override int Bonus => -1;
}