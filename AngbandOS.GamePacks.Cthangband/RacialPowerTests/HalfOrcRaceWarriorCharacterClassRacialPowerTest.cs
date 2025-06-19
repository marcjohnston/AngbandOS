namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceWarriorCharacterClassRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 3;
    public override string CostExpression => "5";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);

    /// <summary>
    /// Warrior Orcs override the base 10 difficultly down to 5.
    /// </summary>
    public override int Difficulty => 5;
}