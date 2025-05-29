namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class NibelungRaceRacialPowerTest : RacialPowerTest
{
    private NibelungRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 5;
    public override string CostExpression => "5";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 10;
}