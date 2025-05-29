namespace AngbandOS.Core.RacialPowerTests;

[Serializable]
internal class HalfTrollRaceWarriorCharacterClassRacialPowerTest : RacialPowerTest
{
    private HalfTrollRaceWarriorCharacterClassRacialPowerTest(Game game) : base(game) { }
    public override int MinLevel => 10;
    public override string CostExpression => "12";
    public override string AbilityBindingKey => nameof(WisdomAbility);

    /// <summary>
    /// Warrior Half-Trolls override the base 12 difficultly down to 6.
    /// </summary>
    public override int Difficulty => 6;
}