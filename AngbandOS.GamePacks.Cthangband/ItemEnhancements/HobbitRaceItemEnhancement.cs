namespace AngbandOS.GamePacks.Cthangband;
public class HobbitRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustDexAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "1"),
        (nameof(BonusIntelligenceAttribute), "2"),
        (nameof(BonusDexterityAttribute), "3"),
        (nameof(ValueAttribute), "7650"),
        (nameof(InfraVisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "15"),
        (nameof(SavingThrowAttribute), "18"),
        (nameof(StealthAttribute), "5"),
        (nameof(SearchAttribute), "60"),
        (nameof(BonusStrengthAttribute), "-2"),
        (nameof(UseDeviceAttribute), "18"),
    };
}
