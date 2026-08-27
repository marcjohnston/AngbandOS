namespace AngbandOS.GamePacks.Cthangband;
public class KoboldRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResPoisAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-4"),
        (nameof(BonusConstitutionAttribute), "0"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "-1"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "-600"),
        (nameof(InfraVisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-2"),
        (nameof(SavingThrowAttribute), "-2"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "5"),
        (nameof(BonusStrengthAttribute), "1"),
        (nameof(UseDeviceAttribute), "-3"),
    };
}
