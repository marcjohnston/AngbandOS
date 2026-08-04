namespace AngbandOS.GamePacks.Cthangband;
public class HalfTrollRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustStrAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-6"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "-4"),
        (nameof(DexterityAttribute), "-4"),
        (nameof(ValueAttribute), "-1500"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-8"),
        (nameof(SavingThrowAttribute), "-8"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-1"),
        (nameof(StrengthAttribute), "4")
    };
}
