namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearGungnirFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfLightning100r3Every500DirectionalActivation);
    public override bool Blessed => true;
    public override bool BrandElec => true;
    public override bool BrandFire => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Gungnir'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a spear which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusIntelligenceRollExpression => "4";
    public override string? BonusWisdomRollExpression => "4";
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override bool Wis => true;
    public override int Cost => 180000;
}
