namespace AngbandOS.GamePacks.Cthangband;

public class CyclopsRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 20;
    public override string CostExpression => "15";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Difficulty => 12;
}