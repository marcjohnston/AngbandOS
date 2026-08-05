namespace AngbandOS.GamePacks.Cthangband;
public class VampireRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResNetherAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResPoisAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(GlowRadiusAttribute), "1"),
        (nameof(StrengthAttribute), "3"),
        (nameof(CharismaAttribute), "2"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(WisdomAttribute), "-1"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "-1"),
        (nameof(ValueAttribute), "6900"),
        (nameof(InfravisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "4"),
        (nameof(UseDeviceAttribute), "10"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "4"),
        (nameof(SearchAttribute), "1"),
    };
}
