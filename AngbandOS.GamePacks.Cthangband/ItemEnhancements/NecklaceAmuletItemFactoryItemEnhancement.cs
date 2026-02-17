namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NecklaceAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "75000"),
    };
}
