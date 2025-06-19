namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GnomeRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 5;
    public override string CostExpression => "5 + (X / 5)";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 12;
}