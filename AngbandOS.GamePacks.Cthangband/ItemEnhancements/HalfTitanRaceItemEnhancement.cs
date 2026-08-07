namespace AngbandOS.GamePacks.Cthangband;
public class HalfTitanRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResConfAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "3"),
        (nameof(BonusWisdomAttribute), "1"),
        (nameof(BonusIntelligenceAttribute), "1"),
        (nameof(BonusDexterityAttribute), "-2"),
        (nameof(ValueAttribute), "10050"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "2"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "1"),
        (nameof(BonusStrengthAttribute), "5")
    };
}
