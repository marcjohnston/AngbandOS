namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DraconianRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "-3";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "1";
    public override string BonusIntelligenceRollExpression => "1";
    public override string BonusDexterityRollExpression => "1";
    public override int? Value => 7050;
    public override string? BonusInfravisionRollExpression => "2";
}
