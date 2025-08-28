namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ZombieRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "-5";
    public override string BonusConstitutionRollExpression => "4";
    public override string BonusWisdomRollExpression => "-6";
    public override string BonusIntelligenceRollExpression => "-6";
    public override string BonusDexterityRollExpression => "1";
    public override int? Value => -8250;
}
