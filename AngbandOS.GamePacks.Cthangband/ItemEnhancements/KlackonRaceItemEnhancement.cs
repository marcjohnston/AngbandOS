namespace AngbandOS.GamePacks.Cthangband;
public class KlackonRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResConfAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SpeedAttribute), "X/10"),
        (nameof(BonusCharismaAttribute), "-2"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "-1"),
        (nameof(BonusIntelligenceAttribute), "-1"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "2700"),
        (nameof(InfraVisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "5"),
        (nameof(StealthAttribute), "0"),
        (nameof(SearchAttribute), "-1"),
        (nameof(BonusStrengthAttribute), "2"),
    };
}
