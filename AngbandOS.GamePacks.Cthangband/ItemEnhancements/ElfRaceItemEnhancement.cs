namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-1";
    public override string BonusCharismaRollExpression => "2";
    public override string BonusConstitutionRollExpression => "-2";
    public override string BonusWisdomRollExpression => "2";
    public override string BonusIntelligenceRollExpression => "2";
    public override string BonusDexterityRollExpression => "1";
    public override int? Value => 3300;
    public override string? BonusInfravisionRollExpression => "3";
}
