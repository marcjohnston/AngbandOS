namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RangerCharacterClassDexterityAbility : CharacterClassAbility
{
    private RangerCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(RangerCharacterClass);
    public override int Bonus => 1;
}