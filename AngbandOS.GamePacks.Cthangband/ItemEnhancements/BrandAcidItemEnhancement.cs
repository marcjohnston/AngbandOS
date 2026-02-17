namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandAcidItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandAcid => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
    };
}
