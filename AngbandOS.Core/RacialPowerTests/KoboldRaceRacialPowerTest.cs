namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class KoboldRaceRacialPowerTest : RacialPowerTest
{
    private KoboldRaceRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 12;
    public override string CostExpression => "8";
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override int Difficulty => 14;
}