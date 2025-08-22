namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TchoTchoRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "3";
    public override string BonusCharismaRollExpression => "-2";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "-1";
    public override string BonusIntelligenceRollExpression => "-2";
    public override string BonusDexterityRollExpression => "1";
}
