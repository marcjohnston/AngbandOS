namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class GreatOneRaceTravelPowerRacialPowerTest : RacialPowerTest
{
    private GreatOneRaceTravelPowerRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 30;
    public override string CostExpression => "50";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 50;
}