namespace AngbandOS.GamePacks.Cthangband;
public class KoboldRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResPoisAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-4"),
        (nameof(ConstitutionAttribute), "0"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "-600"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-2"),
        (nameof(UseDeviceAttribute), "-3"),
        (nameof(SavingThrowAttribute), "-2"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "1"),
        (nameof(StrengthAttribute), "1"),
    };
}
