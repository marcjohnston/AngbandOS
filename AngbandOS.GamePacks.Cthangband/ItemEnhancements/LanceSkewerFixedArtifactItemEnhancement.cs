namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LanceSkewerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 20;
    public override bool Dex => true;
    public override string FriendlyName => "'Skewer'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "2";
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
}