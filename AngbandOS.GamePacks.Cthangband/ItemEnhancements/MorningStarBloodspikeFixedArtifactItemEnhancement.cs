namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MorningStarBloodspikeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string FriendlyName => "'Bloodspike'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusStrengthRollExpression => "4";
    public override bool ResNexus => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override int Value => 30000;
    public override string BonusHitsRollExpression => "8";
    public override string BonusDamageRollExpression => "22";
    public override ColorEnum Color => ColorEnum.Black;
}
