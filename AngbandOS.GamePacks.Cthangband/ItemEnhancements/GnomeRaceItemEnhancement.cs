namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GnomeRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-1";
    public override string BonusCharismaRollExpression => "-2";
    public override string BonusConstitutionRollExpression => "1";
    public override string BonusWisdomRollExpression => "0";
    public override string BonusIntelligenceRollExpression => "2";
    public override string BonusDexterityRollExpression => "2";
    public override int? Value => 3900;
    public override string? BonusInfravisionRollExpression => "4";
}
