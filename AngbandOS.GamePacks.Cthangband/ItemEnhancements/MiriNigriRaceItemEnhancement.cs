namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MiriNigriRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "-4";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "-1";
    public override string BonusIntelligenceRollExpression => "-2";
    public override string BonusDexterityRollExpression => "-1";
    public override int? Value => -1800;
}
