namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class GreatOneRaceDreamingPowerRacialPowerTest : RacialPowerTest
{
    private GreatOneRaceDreamingPowerRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 40;
    public override string CostExpression => "75";
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override int Difficulty => 50;
}