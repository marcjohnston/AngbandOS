namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalCapOfHolinessFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Cha => true;
    public override string FriendlyName => "of Holiness";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusCharismaRollExpression => "3";
    public override string? BonusWisdomRollExpression => "3";
    public override bool Wis => true;
    public override int Cost => 22000;
}
