namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChannelerCharacterClassWisdomAbility : CharacterClassAbility
{
    private ChannelerCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(ChannelerCharacterClass);
    public override int Bonus => 2;
}