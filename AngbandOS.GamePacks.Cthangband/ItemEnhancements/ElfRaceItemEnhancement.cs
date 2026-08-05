namespace AngbandOS.GamePacks.Cthangband;
public class ElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResLightAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "2"),
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "3300"),
        (nameof(InfraVisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "5"),
        (nameof(UseDeviceAttribute), "6"),
        (nameof(SavingThrowAttribute), "6"),
        (nameof(StealthAttribute), "2"),
        (nameof(SearchAttribute), "8"),
        (nameof(StrengthAttribute), "-1")
    };
}
