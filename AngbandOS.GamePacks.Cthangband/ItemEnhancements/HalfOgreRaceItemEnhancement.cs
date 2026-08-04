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
        (nameof(CharismaAttribute), "-3"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(WisdomAttribute), "-1"),
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(DexterityAttribute), "-1"),
        (nameof(ValueAttribute), "2250"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-3"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "-5"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-1"),
        (nameof(StrengthAttribute), "3")
    };
}
