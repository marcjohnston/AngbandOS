namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DarkElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-1";
    public override string BonusCharismaRollExpression => "1";
    public override string BonusConstitutionRollExpression => "-2";
    public override string BonusWisdomRollExpression => "2";
    public override string BonusIntelligenceRollExpression => "3";
    public override string BonusDexterityRollExpression => "2";
}
