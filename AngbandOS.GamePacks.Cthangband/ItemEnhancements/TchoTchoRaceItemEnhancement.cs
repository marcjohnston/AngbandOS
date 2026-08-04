namespace AngbandOS.GamePacks.Cthangband;
public class TchoTchoRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResFearAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "3"),
        (nameof(CharismaAttribute), "-2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "-1"),
        (nameof(IntelligenceAttribute), "-2"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "2700"),
        (nameof(DisarmTrapsAttribute), "-2"),
        (nameof(UseDeviceAttribute), "-10"),
        (nameof(SavingThrowAttribute), "2"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "1"),
    };
}
