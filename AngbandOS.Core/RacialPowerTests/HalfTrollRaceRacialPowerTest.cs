namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HalfTrollRaceRacialPowerTest : RacialPowerTest
{
    private HalfTrollRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 10;
    public override string CostExpression => "12";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 12;
}