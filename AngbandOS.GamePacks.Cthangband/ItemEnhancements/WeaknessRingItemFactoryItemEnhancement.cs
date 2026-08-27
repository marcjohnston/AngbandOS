namespace AngbandOS.GamePacks.Cthangband;

public class WeaknessRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IsCursedAttribute), "true"),
        (nameof(HatesElectricityAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(ValuelessAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "-5"),
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "-11000"),
    };
}
