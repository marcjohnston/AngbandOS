namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HobbitRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 15;
    public override string CostExpression => "10";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 10;
}