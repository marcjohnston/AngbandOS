namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HalfTitanRaceRacialPowerTest : RacialPowerTest
{
    private HalfTitanRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 35;
    public override string CostExpression => "20";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 12;
}