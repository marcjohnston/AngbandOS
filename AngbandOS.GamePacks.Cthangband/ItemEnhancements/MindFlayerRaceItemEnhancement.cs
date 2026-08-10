namespace AngbandOS.GamePacks.Cthangband;
public class MindFlayerRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustWisAttribute), "true"),
        (nameof(SustIntAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "-3"),
        (nameof(BonusCharismaAttribute), "-5"),
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusWisdomAttribute), "4"),
        (nameof(BonusIntelligenceAttribute), "4"),
        (nameof(BonusDexterityAttribute), "0"),
        (nameof(ValueAttribute), "1350"),
        (nameof(InfraVisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "25"),
        (nameof(SavingThrowAttribute), "15"),
        (nameof(StealthAttribute), "2"),
        (nameof(SearchAttribute), "5"),
        (nameof(UseDeviceAttribute), "25"),
    };
}
