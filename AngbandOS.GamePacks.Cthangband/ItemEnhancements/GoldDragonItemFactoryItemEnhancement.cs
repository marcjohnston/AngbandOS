namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GoldDragonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfSound130r2Every1d450p450DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResSound => true;
    public override int TreasureRating => 30;
}