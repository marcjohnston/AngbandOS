namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTrollRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "4";
    public override string BonusCharismaRollExpression => "-6";
    public override string BonusConstitutionRollExpression => "3";
    public override string BonusWisdomRollExpression => "2";
    public override string BonusIntelligenceRollExpression => "-4";
    public override string BonusDexterityRollExpression => "-4";
    public override int Value => -1500;
}
