namespace AngbandOS.GamePacks.Cthangband;

public class ZombieRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 30;
    public override string CostExpression => "30";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Difficulty => 18;
}