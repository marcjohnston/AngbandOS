namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GolemRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 20;
    public override string CostExpression => "15";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Difficulty => 8;
}