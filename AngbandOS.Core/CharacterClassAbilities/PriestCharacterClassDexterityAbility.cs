namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PriestCharacterClassDexterityAbility : CharacterClassAbility
{
    private PriestCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(PriestCharacterClass);
    public override int Bonus => -1;
}