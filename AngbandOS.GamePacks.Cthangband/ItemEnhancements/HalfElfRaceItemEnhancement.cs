namespace AngbandOS.GamePacks.Cthangband;
public class HalfElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResLightAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "-1"),
        (nameof(BonusWisdomAttribute), "1"),
        (nameof(BonusIntelligenceAttribute), "1"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "1650"),
        (nameof(InfraVisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "2"),
        (nameof(UseDeviceAttribute), "3"),
        (nameof(SavingThrowAttribute), "3"),
        (nameof(StealthAttribute), "1"),
        (nameof(SearchAttribute), "6"),
        (nameof(BonusStrengthAttribute), "-1")
    };
}
