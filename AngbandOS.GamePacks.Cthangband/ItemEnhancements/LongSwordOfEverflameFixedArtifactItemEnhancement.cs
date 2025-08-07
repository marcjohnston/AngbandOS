namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfEverflameFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Everflame shoots a fire ball
    public override string? ActivationName => nameof(ActivationsEnum.BallOfFire72r2Every400DirectionalActivation);
    public override bool BrandFire => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Everflame";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusStrengthRollExpression => "4";
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override bool SustDex => true;
    public override int Cost => 80000;
}
