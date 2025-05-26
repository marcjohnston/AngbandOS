namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class HighMageCharacterClassDexterityAbility : CharacterClassAbility
{
    private HighMageCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(HighMageCharacterClass);
    public override int Bonus => 0;
}