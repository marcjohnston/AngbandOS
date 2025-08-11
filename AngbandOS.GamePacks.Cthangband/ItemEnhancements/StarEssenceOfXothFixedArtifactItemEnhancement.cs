namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceOfXothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.MagicMappingAndIlluminationEvery1d50p50DirectionalActivation);
    public override string FriendlyName => "of Xoth";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusSpeedRollExpression => "1";
    public override bool SeeInvis => true;

    /// <summary>
    /// Returns a value of 1 to add to the radius of light for a star of essence which provides no light.
    /// </summary>
    public override int Radius => 1;
    public override int Cost => 32500;
    public override ColorEnum Color => ColorEnum.Yellow;
}
