namespace AngbandOS.GamePacks.Cthangband;
public class HalfTrollRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustStrAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-6"),
        (nameof(BonusConstitutionAttribute), "3"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "-4"),
        (nameof(BonusDexterityAttribute), "-4"),
        (nameof(ValueAttribute), "-1500"),
        (nameof(InfraVisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(SavingThrowAttribute), "-8"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-1"),
        (nameof(BonusStrengthAttribute), "4"),
        (nameof(UseDeviceAttribute), "-8"),
    };
}
