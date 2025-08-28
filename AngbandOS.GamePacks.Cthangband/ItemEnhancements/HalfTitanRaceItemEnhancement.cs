namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTitanRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "5";
    public override string BonusCharismaRollExpression => "1";
    public override string BonusConstitutionRollExpression => "3";
    public override string BonusWisdomRollExpression => "1";
    public override string BonusIntelligenceRollExpression => "1";
    public override string BonusDexterityRollExpression => "-2";
    public override int? Value => 10050;
}
