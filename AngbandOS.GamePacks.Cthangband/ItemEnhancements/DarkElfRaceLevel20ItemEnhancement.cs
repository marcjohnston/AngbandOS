namespace AngbandOS.GamePacks.Cthangband;

public class DarkElfRaceLevel20ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SeeInvisAttribute), "true")
    };

    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "1"),
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ValueAttribute), "5250"),
        (nameof(InfraVisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "5"),
        (nameof(UseDeviceAttribute), "15"),
        (nameof(SavingThrowAttribute), "20"),
        (nameof(StealthAttribute), "3"),
        (nameof(SearchAttribute), "8"),
        (nameof(StrengthAttribute), "-1")
    };
}