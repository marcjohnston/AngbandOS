namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 3;
    public override string CostExpression => "5";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Difficulty => 10;
}