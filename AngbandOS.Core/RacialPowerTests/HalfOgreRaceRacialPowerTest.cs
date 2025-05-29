namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HalfOgreRaceRacialPowerTest : RacialPowerTest
{
    private HalfOgreRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 8;
    public override string CostExpression => "10";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 12;
}