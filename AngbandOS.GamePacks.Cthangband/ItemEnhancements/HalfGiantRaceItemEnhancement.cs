namespace AngbandOS.GamePacks.Cthangband;
public class HalfGiantRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustStrAttribute), "true"),
        (nameof(ResShardsAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-3"),
        (nameof(BonusConstitutionAttribute), "3"),
        (nameof(BonusWisdomAttribute), "-2"),
        (nameof(BonusIntelligenceAttribute), "-2"),
        (nameof(BonusDexterityAttribute), "-2"),
        (nameof(ValueAttribute), "-150"),
        (nameof(InfraVisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-6"),
        (nameof(SavingThrowAttribute), "-6"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-5"),
        (nameof(BonusStrengthAttribute), "4"),
        (nameof(UseDeviceAttribute), "-8"),
    };
}
