namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MonkCharacterClassStrengthAbility : CharacterClassAbility
{
    private MonkCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(MonkCharacterClass);
    public override int Bonus => 2;
}