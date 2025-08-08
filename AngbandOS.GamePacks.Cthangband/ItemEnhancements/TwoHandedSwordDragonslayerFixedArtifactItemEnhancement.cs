namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordDragonslayerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Dragonslayer'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int SlayDragon => 5;
    public override string? BonusStrengthRollExpression => "2";
    public override bool Regen => true;
    public override bool ShowMods => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override int Cost => 100000;
}
