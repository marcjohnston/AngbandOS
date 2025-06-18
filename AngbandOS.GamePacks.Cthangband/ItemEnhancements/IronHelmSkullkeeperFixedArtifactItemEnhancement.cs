namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmSkullkeeperFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Skull Keeper detects everything
    public override string? ActivationName => nameof(ActivationsEnum.DetectionEvery55p1d55Activation);
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Skullkeeper'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override string? BonusIntelligenceRollExpression => "2";
    public override string? BonusWisdomRollExpression => "2";
    public override bool ResBlind => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool Wis => true;
}