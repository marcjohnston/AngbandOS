namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatOneRaceTravelPowerRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 30;
    public override string CostExpression => "50";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 50;
}