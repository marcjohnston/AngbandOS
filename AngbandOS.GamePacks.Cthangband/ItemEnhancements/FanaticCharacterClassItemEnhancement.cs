
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FanaticCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "-2";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "0";
    public override string BonusIntelligenceRollExpression => "1";
    public override string BonusDexterityRollExpression => "1";
}
