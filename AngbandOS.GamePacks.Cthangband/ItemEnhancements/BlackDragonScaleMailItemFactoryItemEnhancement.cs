namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlackDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfAcid130r2Every1d450p450DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResAcid => true;
    public override int TreasureRating => 30;
    public override int Weight => 200;
}