namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TchoTchoRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 25;
    public override string CostExpression => "35";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 15;
}