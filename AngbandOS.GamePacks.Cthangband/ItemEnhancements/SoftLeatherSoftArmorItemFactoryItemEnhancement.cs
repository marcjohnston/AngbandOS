namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoftLeatherSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(HatesFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "80"),
        (nameof(ValueAttribute), "18"),
        (nameof(BaseArmorClassAttribute), "4"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
