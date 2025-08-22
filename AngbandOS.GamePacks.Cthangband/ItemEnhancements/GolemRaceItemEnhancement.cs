namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GolemRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "4";
    public override string BonusCharismaRollExpression => "-4";
    public override string BonusConstitutionRollExpression => "4";
    public override string BonusWisdomRollExpression => "-5";
    public override string BonusIntelligenceRollExpression => "-5";
    public override string BonusDexterityRollExpression => "0";
}
