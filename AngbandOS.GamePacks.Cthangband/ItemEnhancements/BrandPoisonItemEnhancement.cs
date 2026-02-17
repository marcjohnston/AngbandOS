namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandPoisonItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandPois => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
    };
}
