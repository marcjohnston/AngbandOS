namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChannelerCharacterClassStrengthAbility : CharacterClassAbility
{
    private ChannelerCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(ChannelerCharacterClass);
    public override int Bonus => -1;
}