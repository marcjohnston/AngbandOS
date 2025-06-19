namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpriteRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 12;
    public override string CostExpression => "12";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Difficulty => 15;
}