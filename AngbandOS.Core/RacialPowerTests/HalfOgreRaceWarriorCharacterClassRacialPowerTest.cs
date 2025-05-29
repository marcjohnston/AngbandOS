namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HalfOgreRaceWarriorCharacterClassRacialPowerTest : RacialPowerTest
{
    private HalfOgreRaceWarriorCharacterClassRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 8;
    public override string CostExpression => "10";
    public override string AbilityBindingKey => nameof(WisdomAbility);

    /// <summary>
    /// Warrior Ogres override the base 12 difficultly down to 6.
    /// </summary>
    public override int Difficulty => 6;
}