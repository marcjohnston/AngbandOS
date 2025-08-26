
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DruidCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-1";
    public override string BonusCharismaRollExpression => "3";
    public override string BonusConstitutionRollExpression => "0";
    public override string BonusWisdomRollExpression => "4";
    public override string BonusIntelligenceRollExpression => "-3";
    public override string BonusDexterityRollExpression => "-2";
    public override int Value => -1050;
}
