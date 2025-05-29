namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class VampireRaceRacialPowerTest : RacialPowerTest
{
    private VampireRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 2;
    public override string CostExpression => "1 + (X / 3)";
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override int Difficulty => 9;
}