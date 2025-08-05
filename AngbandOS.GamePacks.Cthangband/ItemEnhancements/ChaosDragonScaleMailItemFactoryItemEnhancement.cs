namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfChaos200r2Every1d300p300DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResChaos => true;
    public override bool ResDisen => true;
    public override int TreasureRating => 30;
    public override int Weight => 200;
}