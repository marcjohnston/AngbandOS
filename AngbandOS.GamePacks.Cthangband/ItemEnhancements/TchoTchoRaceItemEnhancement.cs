namespace AngbandOS.GamePacks.Cthangband;
public class TchoTchoRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResFearAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "3"),
        (nameof(BonusCharismaAttribute), "-2"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "-1"),
        (nameof(BonusIntelligenceAttribute), "-2"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "2700"),
        (nameof(DisarmTrapsAttribute), "-2"),
        (nameof(UseDeviceAttribute), "-10"),
        (nameof(SavingThrowAttribute), "2"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "1"),
    };
}
