namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-1";
    public override string BonusCharismaRollExpression => "1";
    public override string BonusConstitutionRollExpression => "-1";
    public override string BonusWisdomRollExpression => "1";
    public override string BonusIntelligenceRollExpression => "1";
    public override string BonusDexterityRollExpression => "1";
    public override int Value => 1650;
}
