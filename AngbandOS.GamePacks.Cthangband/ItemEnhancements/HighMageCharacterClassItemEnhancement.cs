
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-5";
    public override string BonusCharismaRollExpression => "1";
    public override string BonusConstitutionRollExpression => "-2";
    public override string BonusWisdomRollExpression => "0";
    public override string BonusIntelligenceRollExpression => "4";
    public override string BonusDexterityRollExpression => "0";
    public override int Value => -3150;
}
