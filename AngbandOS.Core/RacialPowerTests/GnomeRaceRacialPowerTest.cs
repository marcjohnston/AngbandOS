namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class GnomeRaceRacialPowerTest : RacialPowerTest
{
    private GnomeRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 5;
    public override string CostExpression => "5 + (X / 5)";
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override int Difficulty => 12;
}