namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class CultistCharacterClassDexterityAbility : CharacterClassAbility
{
    private CultistCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(CultistCharacterClass);
    public override int Bonus => 1;
}