namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfOrcRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "-4";
    public override string BonusConstitutionRollExpression => "1";
    public override string BonusWisdomRollExpression => "0";
    public override string BonusIntelligenceRollExpression => "-1";
    public override string BonusDexterityRollExpression => "0";
}
