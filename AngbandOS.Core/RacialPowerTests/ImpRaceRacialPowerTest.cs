namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class ImpRaceRacialPowerTest : RacialPowerTest
{
    private ImpRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 9;
    public override string CostExpression => "15";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 15;
}