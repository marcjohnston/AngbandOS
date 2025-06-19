namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KoboldRaceRacialPowerTest : RacialPowerTestGameConfiguration
{
    public override int MinLevel => 12;
    public override string CostExpression => "8";
    public override string UseAbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Difficulty => 14;
}