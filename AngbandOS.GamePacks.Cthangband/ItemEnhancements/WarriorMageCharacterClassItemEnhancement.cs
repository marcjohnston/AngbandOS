
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "2";
    public override string BonusCharismaRollExpression => "1";
    public override string BonusConstitutionRollExpression => "0";
    public override string BonusWisdomRollExpression => "0";
    public override string BonusIntelligenceRollExpression => "2";
    public override string BonusDexterityRollExpression => "1";
}
