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
        (nameof(BonusCharismaAttribute), "-4"),
        (nameof(BonusConstitutionAttribute), "4"),
        (nameof(BonusWisdomAttribute), "-5"),
        (nameof(BonusIntelligenceAttribute), "-5"),
        (nameof(BonusDexterityAttribute), "0"),
        (nameof(ValueAttribute), "-4200"),
        (nameof(InfraVisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
        (nameof(BonusStrengthAttribute), "4")
    };
}
