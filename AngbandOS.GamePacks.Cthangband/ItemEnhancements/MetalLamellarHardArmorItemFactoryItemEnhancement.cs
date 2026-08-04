namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalLamellarHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(ReflectAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "340"),
        (nameof(ValueAttribute), "1250"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "6"),
        (nameof(MeleeToHitAttribute), "-3"),
        (nameof(BaseArmorClassAttribute), "23"),
    };
}
