namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CarlammasAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "60000"),
    };
}
