namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherCapHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(ReflectAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "15"),
        (nameof(ValueAttribute), "12"),
        (nameof(BaseArmorClassAttribute), "2"),
    };
    public override ColorEnum? Color => ColorEnum.Brown;
}
