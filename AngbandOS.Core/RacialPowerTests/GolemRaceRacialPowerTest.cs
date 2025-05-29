namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class GolemRaceRacialPowerTest : RacialPowerTest
{
    private GolemRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 20;
    public override string CostExpression => "15";
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override int Difficulty => 8;
}