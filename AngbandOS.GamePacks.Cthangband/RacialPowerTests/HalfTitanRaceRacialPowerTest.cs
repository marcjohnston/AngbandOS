namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTitanRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 35;
    public override string CostExpression => "20";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 12;
}