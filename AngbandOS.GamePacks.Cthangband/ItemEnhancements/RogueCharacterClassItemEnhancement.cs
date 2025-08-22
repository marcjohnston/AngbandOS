
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "-1";
    public override string BonusConstitutionRollExpression => "1";
    public override string BonusWisdomRollExpression => "-2";
    public override string BonusIntelligenceRollExpression => "1";
    public override string BonusDexterityRollExpression => "3";
}
