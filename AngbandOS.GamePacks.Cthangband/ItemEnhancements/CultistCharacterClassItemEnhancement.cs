
namespace AngbandOS.GamePacks.Cthangband;

public class CultistCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ReceivesLevelRewardsAttribute), "true")
    };

    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-2"),
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "4"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(BonusStrengthAttribute), "-5"),
        (nameof(ValueAttribute), "-3300"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(SavingThrowAttribute), "32"),
        (nameof(SavingThrowBonusPerLevelAttribute), "10"),
        (nameof(UseDeviceAttribute), "36"),
        (nameof(UseDeviceBonusPerLevelAttribute), "13"),
        (nameof(SearchAttribute), "16"),
        (nameof(StealthAttribute), "2")
    };
}
