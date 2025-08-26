namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ImpRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-1";
    public override string BonusCharismaRollExpression => "-3";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "-1";
    public override string BonusIntelligenceRollExpression => "-1";
    public override string BonusDexterityRollExpression => "1";
    public override int Value => -1350;
}
