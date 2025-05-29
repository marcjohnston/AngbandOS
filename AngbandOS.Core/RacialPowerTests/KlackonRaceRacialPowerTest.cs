namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class KlackonRaceRacialPowerTest : RacialPowerTest
{
    private KlackonRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 9;
    public override string CostExpression => "9";
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override int Difficulty => 14;
}