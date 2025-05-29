namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class MindFlayerRaceRacialPowerTest : RacialPowerTest
{
    private MindFlayerRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 15;
    public override string CostExpression => "12";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 14;
}