namespace AngbandOS.GamePacks.Cthangband;

public class DarkElfRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 2;
    public override string CostExpression => "2";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 9;
}