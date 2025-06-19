namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VampireRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 2;
    public override string CostExpression => "1 + (X / 3)";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Difficulty => 9;
}