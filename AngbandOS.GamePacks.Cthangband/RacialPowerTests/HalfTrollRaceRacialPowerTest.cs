namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTrollRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 10;
    public override string CostExpression => "12";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Difficulty => 12;
}