namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfOgreRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "3";
    public override string BonusCharismaRollExpression => "-3";
    public override string BonusConstitutionRollExpression => "3";
    public override string BonusWisdomRollExpression => "-1";
    public override string BonusIntelligenceRollExpression => "-1";
    public override string BonusDexterityRollExpression => "-1";
    public override int? Value => 2250;
    public override string? BonusInfravisionRollExpression => "3";
}
