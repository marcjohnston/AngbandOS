namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class ZombieRaceRacialPowerTest : RacialPowerTest
{
    private ZombieRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 30;
    public override string CostExpression => "30";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 18;
}