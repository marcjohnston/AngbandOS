namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BronzeDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfConfusion120r2Every1d450p450DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResConf => true;
    public override int TreasureRating => 30;
    public override int Weight => 200;
}