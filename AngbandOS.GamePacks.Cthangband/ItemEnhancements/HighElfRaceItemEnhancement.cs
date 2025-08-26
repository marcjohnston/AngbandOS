namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HighElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "1";
    public override string BonusCharismaRollExpression => "5";
    public override string BonusConstitutionRollExpression => "1";
    public override string BonusWisdomRollExpression => "2";
    public override string BonusIntelligenceRollExpression => "3";
    public override string BonusDexterityRollExpression => "3";
    public override int Value => 14250;
}
