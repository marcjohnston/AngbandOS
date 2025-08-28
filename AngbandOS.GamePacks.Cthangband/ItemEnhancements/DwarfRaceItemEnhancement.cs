namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DwarfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "-3";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "2";
    public override string BonusIntelligenceRollExpression => "-2";
    public override string BonusDexterityRollExpression => "-2";
    public override int? Value => 1050;
}
