namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfMetalShodBootsOfTheBlackReaverFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Aggravate => true;
    public override bool Con => true;
    public override string FriendlyName => "of the Black Reaver";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "10";
    public override string? BonusSpeedRollExpression => "10";
    public override string? BonusStrengthRollExpression => "10";
    public override bool Speed => true;
    public override bool Str => true;
}