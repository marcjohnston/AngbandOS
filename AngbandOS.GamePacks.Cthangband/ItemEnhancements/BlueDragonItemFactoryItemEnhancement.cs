namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlueDragonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfLightning100r2Every1d450p450DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResElec => true;
    public override int TreasureRating => 30;
}