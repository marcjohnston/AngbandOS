namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ImpRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 9;
    public override string CostExpression => "15";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Difficulty => 15;
}