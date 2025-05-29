namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class SpectreRaceRacialPowerTest : RacialPowerTest
{
    private SpectreRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 4;
    public override string CostExpression => "6";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 3;
}