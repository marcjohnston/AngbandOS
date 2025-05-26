namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class FanaticCharacterClassStrengthAbility : CharacterClassAbility
{
    private FanaticCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(FanaticCharacterClass);
    public override int Bonus => 2;
}