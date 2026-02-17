namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandElectricityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandElec => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
    };
}
