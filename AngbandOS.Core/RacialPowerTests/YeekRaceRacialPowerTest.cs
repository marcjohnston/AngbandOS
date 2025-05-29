namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class YeekRaceRacialPowerTest : RacialPowerTest
{
    private YeekRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 15;
    public override string CostExpression => "15";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 10;
}