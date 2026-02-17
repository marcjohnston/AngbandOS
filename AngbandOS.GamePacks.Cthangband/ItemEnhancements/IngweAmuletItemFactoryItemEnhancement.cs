namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IngweAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "90000"),
    };
}
