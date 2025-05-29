namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HalfOrcRaceWarriorCharacterClassRacialPowerTest : RacialPowerTest
{
    private HalfOrcRaceWarriorCharacterClassRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 3;
    public override string CostExpression => "5";
    public override string AbilityBindingKey => nameof(WisdomAbility);

    /// <summary>
    /// Warrior Orcs override the base 10 difficultly down to 5.
    /// </summary>
    public override int Difficulty => 5;
}