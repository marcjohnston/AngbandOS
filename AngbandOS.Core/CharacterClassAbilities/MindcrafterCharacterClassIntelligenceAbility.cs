namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MindcrafterCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private MindcrafterCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(MindcrafterCharacterClass);
    public override int Bonus => 0;
}