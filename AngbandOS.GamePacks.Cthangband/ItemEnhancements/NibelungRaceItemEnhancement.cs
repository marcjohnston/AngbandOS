namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class NibelungRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "1";
    public override string BonusCharismaRollExpression => "-4";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "2";
    public override string BonusIntelligenceRollExpression => "-1";
    public override string BonusDexterityRollExpression => "0";
}
