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
        (nameof(BonusStrengthAttribute), "3"),
        (nameof(BonusCharismaAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "1"),
        (nameof(BonusWisdomAttribute), "-1"),
        (nameof(BonusIntelligenceAttribute), "3"),
        (nameof(BonusDexterityAttribute), "-1"),
        (nameof(ValueAttribute), "6900"),
        (nameof(InfraVisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "4"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "4"),
        (nameof(SearchAttribute), "1"),
        (nameof(UseDeviceAttribute), "10"),
    };
}
