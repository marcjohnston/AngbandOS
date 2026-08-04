namespace AngbandOS.GamePacks.Cthangband;

public class ExtraAttacksRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(AttacksAttribute), "1"),
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "100000"),
    };
}
