namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RogueCharacterClassWisdomAbility : CharacterClassAbility
{
    private RogueCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(RogueCharacterClass);
    public override int Bonus => -2;
}