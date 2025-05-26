namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MonkCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private MonkCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(MonkCharacterClass);
    public override int Bonus => -1;
}