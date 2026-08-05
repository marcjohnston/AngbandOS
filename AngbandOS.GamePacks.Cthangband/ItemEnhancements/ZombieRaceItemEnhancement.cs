namespace AngbandOS.GamePacks.Cthangband;
public class ZombieRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResNetherAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(SlowDigestAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "2"),
        (nameof(CharismaAttribute), "-5"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(WisdomAttribute), "-6"),
        (nameof(IntelligenceAttribute), "-6"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "-8250"),
        (nameof(InfraVisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "8"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
    };
}
