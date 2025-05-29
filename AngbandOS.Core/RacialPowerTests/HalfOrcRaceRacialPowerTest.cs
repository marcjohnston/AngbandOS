namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HalfOrcRaceRacialPowerTest : RacialPowerTest
{
    private HalfOrcRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 3;
    public override string CostExpression => "5";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 10;
}