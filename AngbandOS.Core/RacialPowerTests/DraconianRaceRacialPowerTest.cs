namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class DraconianRaceRacialPowerTest : RacialPowerTest
{
    private DraconianRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 20;
    public override string CostExpression => "15";
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override int Difficulty => 12;
}