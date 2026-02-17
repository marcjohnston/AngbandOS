namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandColdItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandCold => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
    };
}
