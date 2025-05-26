namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MageCharacterClassDexterityAbility : CharacterClassAbility
{
    private MageCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(MageCharacterClass);
    public override int Bonus => 1;
}