namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GemstoneShiningTrapezodedronFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Shining Trapezohedron lights the entire level and recalls us, but drains
    // health to do so
    public override string? ActivationName => nameof(ActivationsEnum.TrapezohedronGemstoneActivation);
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Shining Trapezodedron'";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override string? BonusIntelligenceRollExpression => "3";
    public override string? BonusSpeedRollExpression => "3";
    public override string? BonusWisdomRollExpression => "3";
    public override bool ResChaos => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override bool Wis => true;
    public override int Cost => 150000;
}
