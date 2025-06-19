namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpectreRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 4;
    public override string CostExpression => "6";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 3;
}