namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeatherScaleMailWyvernscaleFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Dex => true;
    public override string FriendlyName => "'Wyvernscale'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "3";
    public override bool ResAcid => true;
    public override bool ResShards => true;
    public override int Weight => -80;
    public override int Cost => 25000;
}
