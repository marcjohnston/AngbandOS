namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffEririlFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Ereril does identify
    public override string? ActivationName => nameof(ActivationsEnum.IdentifyEvery10Activation);
    public override string FriendlyName => "'Eriril'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a quarterstaff which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusIntelligenceRollExpression => "4";
    public override string? BonusWisdomRollExpression => "4";
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override int Value => 20000;
    public override string BonusHitsRollExpression => "3";
    public override string BonusDamageRollExpression => "5";
    public override ColorEnum Color => ColorEnum.BrightBrown;
}
