namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class VampireRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "3";
    public override string BonusCharismaRollExpression => "2";
    public override string BonusConstitutionRollExpression => "1";
    public override string BonusWisdomRollExpression => "-1";
    public override string BonusIntelligenceRollExpression => "3";
    public override string BonusDexterityRollExpression => "-1";
    public override int? Value => 6900;
}
