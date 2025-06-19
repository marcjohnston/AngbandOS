namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOgreRaceWarriorCharacterClassRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 8;
    public override string CostExpression => "10";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);

    /// <summary>
    /// Warrior Ogres override the base 12 difficultly down to 6.
    /// </summary>
    public override int Difficulty => 6;
}