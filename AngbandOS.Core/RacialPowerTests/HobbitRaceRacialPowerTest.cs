namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HobbitRaceRacialPowerTest : RacialPowerTest
{
    private HobbitRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 15;
    public override string CostExpression => "10";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 10;
}