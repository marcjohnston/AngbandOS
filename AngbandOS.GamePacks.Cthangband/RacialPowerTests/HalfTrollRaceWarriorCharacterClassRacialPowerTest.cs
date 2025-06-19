namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTrollRaceWarriorCharacterClassRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 10;
    public override string CostExpression => "12";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);

    /// <summary>
    /// Warrior Half-Trolls override the base 12 difficultly down to 6.
    /// </summary>
    public override int Difficulty => 6;
}