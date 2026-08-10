namespace AngbandOS.GamePacks.Cthangband;
public class SkeletonRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResShardsAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ResPoisAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "0"),
        (nameof(BonusCharismaAttribute), "-4"),
        (nameof(BonusConstitutionAttribute), "1"),
        (nameof(BonusWisdomAttribute), "-2"),
        (nameof(BonusIntelligenceAttribute), "-2"),
        (nameof(BonusDexterityAttribute), "0"),
        (nameof(ValueAttribute), "-5400"),
        (nameof(InfraVisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(SavingThrowAttribute), "5"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
        (nameof(UseDeviceAttribute), "-5"),
    };
}
