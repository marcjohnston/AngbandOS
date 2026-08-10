namespace AngbandOS.GamePacks.Cthangband;
public class GnomeRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-2"),
        (nameof(BonusConstitutionAttribute), "1"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "2"),
        (nameof(BonusDexterityAttribute), "2"),
        (nameof(ValueAttribute), "3900"),
        (nameof(InfraVisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "12"),
        (nameof(SavingThrowAttribute), "12"),
        (nameof(StealthAttribute), "3"),
        (nameof(SearchAttribute), "6"),
        (nameof(BonusStrengthAttribute), "-1"),
        (nameof(UseDeviceAttribute), "12"),
    };
}
