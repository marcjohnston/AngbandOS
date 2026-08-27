namespace AngbandOS.GamePacks.Cthangband;
public class HalfOgreRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustStrAttribute), "true"),
        (nameof(ResDarkAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-3"),
        (nameof(BonusConstitutionAttribute), "3"),
        (nameof(BonusWisdomAttribute), "-1"),
        (nameof(BonusIntelligenceAttribute), "-1"),
        (nameof(BonusDexterityAttribute), "-1"),
        (nameof(ValueAttribute), "2250"),
        (nameof(InfraVisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-3"),
        (nameof(SavingThrowAttribute), "-5"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-5"),
        (nameof(BonusStrengthAttribute), "3"),
        (nameof(UseDeviceAttribute), "-5"),
    };
}
