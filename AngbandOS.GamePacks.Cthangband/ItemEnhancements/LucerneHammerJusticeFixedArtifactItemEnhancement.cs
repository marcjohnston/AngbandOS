namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LucerneHammerJusticeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Justice drains life
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife90Every70DirectionalActivation);
    public override bool BrandCold => true;
    public override string FriendlyName => "'Justice'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a lucrene hammer which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusInfravisionRollExpression => "4";
    public override string? BonusWisdomRollExpression => "4";
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override int Cost => 30000;
    public override string BonusAttacksRollExpression => "8";
    public override string BonusHitsRollExpression => "10";
    public override string BonusDamageRollExpression => "6";
    public override ColorEnum Color => ColorEnum.BrightBlue;
}
