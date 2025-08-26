namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HobbitRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-2";
    public override string BonusCharismaRollExpression => "1";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "1";
    public override string BonusIntelligenceRollExpression => "2";
    public override string BonusDexterityRollExpression => "3";
    public override int Value => 7650;
}
