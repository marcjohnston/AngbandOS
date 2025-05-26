namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChosenOneCharacterClassDexterityAbility : CharacterClassAbility
{
    private ChosenOneCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(ChosenOneCharacterClass);
    public override int Bonus => 2;
}