namespace AngbandOS.GamePacks.Cthangband;
public class HalfOrcRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
   {
        (nameof(ResDarkAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-4"),
        (nameof(BonusConstitutionAttribute), "1"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "-1"),
        (nameof(BonusDexterityAttribute), "0"),
        (nameof(ValueAttribute), "600"),
        (nameof(InfraVisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-3"),
        (nameof(UseDeviceAttribute), "-3"),
        (nameof(SavingThrowAttribute), "-3"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "0"),
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(UseDeviceAttribute), "-3"),
    };
}
