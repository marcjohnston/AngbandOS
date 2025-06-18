namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceOfPolarisFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.IlluminationEvery1d10p10DirectionalActivation);
    public override string FriendlyName => "of Polaris";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override string? BonusSearchRollExpression => "1";
    public override bool Search => true;
    /// <summary>
    /// Returns a value of 1 to add to the radius of light for a star of essence which provides no light.
    /// </summary>
    public override int Radius => 1;
}