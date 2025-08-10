namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SabreOfBluebeardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Blows => true;
    public override string FriendlyName => "of Bluebeard";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusAttacksRollExpression => "1";
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override int SlayDragon => 3;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override int Cost => 25000;
}
