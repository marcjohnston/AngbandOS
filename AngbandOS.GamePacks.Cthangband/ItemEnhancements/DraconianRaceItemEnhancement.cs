namespace AngbandOS.GamePacks.Cthangband;
public class DraconianRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FeatherAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-3"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "1"),
        (nameof(BonusIntelligenceAttribute), "1"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "7050"),
        (nameof(InfraVisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "-2"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "3"),
        (nameof(StealthAttribute), "0"),
        (nameof(SearchAttribute), "1"),
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(UseDeviceAttribute), "5"),
    };
}
