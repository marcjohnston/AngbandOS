namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 20;
    public override string CostExpression => "15";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Difficulty => 12;
}