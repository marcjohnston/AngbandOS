namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatOneRaceDreamingPowerRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 40;
    public override string CostExpression => "75";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Difficulty => 50;
}