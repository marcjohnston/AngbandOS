namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HalfGiantRaceRacialPowerTest : RacialPowerTest
{
    private HalfGiantRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 20;
    public override string CostExpression => "10";
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override int Difficulty => 12;
}