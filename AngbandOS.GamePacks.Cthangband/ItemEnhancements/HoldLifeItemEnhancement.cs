namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HoldLifeItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? HoldLife => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "8500"),
    };
}
