namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfGiantRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 20;
    public override string CostExpression => "10";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Difficulty => 12;
}