
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MysticCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "0";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "2";
    public override string BonusIntelligenceRollExpression => "-1";
    public override string BonusDexterityRollExpression => "2";
    public override int? Value => 8400;
}
