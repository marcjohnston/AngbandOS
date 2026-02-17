namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrillianceAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? HideType => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "500"),
    };
}
