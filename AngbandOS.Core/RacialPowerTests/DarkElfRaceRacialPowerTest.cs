namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class DarkElfRaceRacialPowerTest : RacialPowerTest
{
    private DarkElfRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 2;
    public override string CostExpression => "2";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 9;
}