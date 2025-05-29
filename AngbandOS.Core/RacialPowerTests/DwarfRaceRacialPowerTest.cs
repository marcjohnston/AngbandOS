namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class DwarfRaceRacialPowerTest : RacialPowerTest
{
    private DwarfRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 5;
    public override string CostExpression => "5";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 12;
}