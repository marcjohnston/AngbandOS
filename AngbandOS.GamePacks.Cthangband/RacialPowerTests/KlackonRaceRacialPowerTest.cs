namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KlackonRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 9;
    public override string CostExpression => "9";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Difficulty => 14;
}