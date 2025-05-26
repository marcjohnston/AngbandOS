namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PaladinCharacterClassDexterityAbility : CharacterClassAbility
{
    private PaladinCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(PaladinCharacterClass);
    public override int Bonus => 0;
}