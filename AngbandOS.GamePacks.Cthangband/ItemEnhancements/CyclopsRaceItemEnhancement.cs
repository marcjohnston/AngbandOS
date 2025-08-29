namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CyclopsRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "4";
    public override string BonusCharismaRollExpression => "-6";
    public override string BonusConstitutionRollExpression => "4";
    public override string BonusWisdomRollExpression => "-3";
    public override string BonusIntelligenceRollExpression => "-3";
    public override string BonusDexterityRollExpression => "-3";
    public override int? Value => -3900;
    public override string? BonusInfravisionRollExpression => "1";
}
