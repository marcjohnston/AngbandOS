
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "3";
    public override string BonusCharismaRollExpression => "2";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "1";
    public override string BonusIntelligenceRollExpression => "-3";
    public override string BonusDexterityRollExpression => "0";
    public override int Value => 4500;
}
