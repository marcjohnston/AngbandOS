
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChannelerCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-1";
    public override string BonusCharismaRollExpression => "3";
    public override string BonusConstitutionRollExpression => "-1";
    public override string BonusWisdomRollExpression => "2";
    public override string BonusIntelligenceRollExpression => "0";
    public override string BonusDexterityRollExpression => "-1";
}
