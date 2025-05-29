namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class SpriteRaceRacialPowerTest : RacialPowerTest
{
    private SpriteRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 12;
    public override string CostExpression => "12";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 15;
}