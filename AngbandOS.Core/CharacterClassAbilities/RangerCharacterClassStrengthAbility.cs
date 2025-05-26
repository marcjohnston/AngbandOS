namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RangerCharacterClassStrengthAbility : CharacterClassAbility
{
    private RangerCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(RangerCharacterClass);
    public override int Bonus => 2;
}