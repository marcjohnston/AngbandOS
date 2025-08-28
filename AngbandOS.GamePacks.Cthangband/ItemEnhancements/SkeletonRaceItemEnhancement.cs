namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SkeletonRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "0";
    public override string BonusCharismaRollExpression => "-4";
    public override string BonusConstitutionRollExpression => "1";
    public override string BonusWisdomRollExpression => "-2";
    public override string BonusIntelligenceRollExpression => "-2";
    public override string BonusDexterityRollExpression => "0";
    public override int? Value => -5400;
}
