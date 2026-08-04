namespace AngbandOS.GamePacks.Cthangband;

public class MindFlayerRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 15;
    public override string CostExpression => "12";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 14;
}