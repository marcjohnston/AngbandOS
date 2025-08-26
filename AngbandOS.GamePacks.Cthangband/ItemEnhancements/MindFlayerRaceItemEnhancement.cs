namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MindFlayerRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-3";
    public override string BonusCharismaRollExpression => "-5";
    public override string BonusConstitutionRollExpression => "-2";
    public override string BonusWisdomRollExpression => "4";
    public override string BonusIntelligenceRollExpression => "4";
    public override string BonusDexterityRollExpression => "0";
    public override int Value => 1350;
}
