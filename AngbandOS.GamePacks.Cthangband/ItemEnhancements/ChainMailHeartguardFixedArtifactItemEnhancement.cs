namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChainMailHeartguardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Cha => true;
    public override string FriendlyName => "'Heartguard'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusCharismaRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResNexus => true;
    public override bool ResShards => true;
    public override bool Str => true;
}