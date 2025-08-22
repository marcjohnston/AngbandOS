namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class KoboldRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "1";
    public override string BonusCharismaRollExpression => "-4";
    public override string BonusConstitutionRollExpression => "0";
    public override string BonusWisdomRollExpression => "0";
    public override string BonusIntelligenceRollExpression => "-1";
    public override string BonusDexterityRollExpression => "1";
}
