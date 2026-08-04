namespace AngbandOS.GamePacks.Cthangband;
public class GolemRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SlowDigestAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ResPoisAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusArmorClassAttribute), "20+X/5"),
        (nameof(CharismaAttribute), "-4"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(WisdomAttribute), "-5"),
        (nameof(IntelligenceAttribute), "-5"),
        (nameof(DexterityAttribute), "0"),
        (nameof(ValueAttribute), "-4200"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
        (nameof(StrengthAttribute), "4")
    };
}
