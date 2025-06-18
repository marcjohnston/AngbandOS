namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerCharityFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Charity shoots a lightning bolt
    public override string? ActivationName => nameof(ActivationsEnum.LightningBolt4d8Every6p1d6DirectionalActivation);
    public override bool BrandElec => true;
    public override string FriendlyName => "'Charity'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResElec => true;
    public override bool ShowMods => true;
}