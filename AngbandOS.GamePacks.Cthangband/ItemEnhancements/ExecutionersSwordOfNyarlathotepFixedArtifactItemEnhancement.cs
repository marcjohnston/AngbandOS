namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExecutionersSwordOfNyarlathotepFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool BrandPois => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "of Nyarlathotep";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool Vorpal => true;
}