namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandFireItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
    };
}
