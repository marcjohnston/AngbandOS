
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindcrafterCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-1";
    public override string BonusCharismaRollExpression => "2";
    public override string BonusConstitutionRollExpression => "-1";
    public override string BonusWisdomRollExpression => "3";
    public override string BonusIntelligenceRollExpression => "0";
    public override string BonusDexterityRollExpression => "-1";
    public override int Value => 900;
}
