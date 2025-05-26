namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MonkCharacterClassDexterityAbility : CharacterClassAbility
{
    private MonkCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(MonkCharacterClass);
    public override int Bonus => 3;
}