namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NibelungRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 5;
    public override string CostExpression => "5";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Difficulty => 10;
}