namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SpectreRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-5";
    public override string BonusCharismaRollExpression => "-6";
    public override string BonusConstitutionRollExpression => "-3";
    public override string BonusWisdomRollExpression => "4";
    public override string BonusIntelligenceRollExpression => "4";
    public override string BonusDexterityRollExpression => "2";
    public override int? Value => -300;
}
