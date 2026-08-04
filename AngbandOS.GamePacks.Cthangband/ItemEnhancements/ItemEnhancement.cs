namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "50"),
    };
}