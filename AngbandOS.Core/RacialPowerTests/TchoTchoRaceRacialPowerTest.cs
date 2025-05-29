namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class TchoTchoRaceRacialPowerTest : RacialPowerTest
{
    private TchoTchoRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 25;
    public override string CostExpression => "35";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 15;
}