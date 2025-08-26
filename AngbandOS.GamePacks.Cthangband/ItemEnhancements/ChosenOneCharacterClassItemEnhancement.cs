
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChosenOneCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "3";
    public override string BonusCharismaRollExpression => "-1";
    public override string BonusConstitutionRollExpression => "2";
    public override string BonusWisdomRollExpression => "-2";
    public override string BonusIntelligenceRollExpression => "-2";
    public override string BonusDexterityRollExpression => "2";
    public override int Value => 3150;
}
