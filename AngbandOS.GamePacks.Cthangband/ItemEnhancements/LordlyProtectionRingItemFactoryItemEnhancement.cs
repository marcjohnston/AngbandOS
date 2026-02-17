namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LordlyProtectionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "5"),
        (nameof(ValueAttribute), "100000"),
        (nameof(WeightAttribute), "2"),
    };
}
