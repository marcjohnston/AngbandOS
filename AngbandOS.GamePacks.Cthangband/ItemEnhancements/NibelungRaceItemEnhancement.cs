namespace AngbandOS.GamePacks.Cthangband;
public class NibelungRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResDarkAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "1"),
        (nameof(BonusCharismaAttribute), "-4"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "-1"),
        (nameof(BonusDexterityAttribute), "0"),
        (nameof(ValueAttribute), "3000"),
        (nameof(InfraVisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "3"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "1"),
        (nameof(SearchAttribute), "5"),
    };
}
