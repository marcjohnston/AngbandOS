namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RogueCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private RogueCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(RogueCharacterClass);
    public override int Bonus => 1;
}