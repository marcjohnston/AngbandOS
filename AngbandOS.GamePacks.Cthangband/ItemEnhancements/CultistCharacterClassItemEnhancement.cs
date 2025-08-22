
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultistCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-5";
    public override string BonusCharismaRollExpression => "-2";
    public override string BonusConstitutionRollExpression => "-2";
    public override string BonusWisdomRollExpression => "0";
    public override string BonusIntelligenceRollExpression => "4";
    public override string BonusDexterityRollExpression => "1";
}
