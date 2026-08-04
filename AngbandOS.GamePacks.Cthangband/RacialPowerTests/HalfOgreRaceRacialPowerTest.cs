namespace AngbandOS.GamePacks.Cthangband;

public class HalfOgreRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 8;
    public override string CostExpression => "10";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Difficulty => 12;
}