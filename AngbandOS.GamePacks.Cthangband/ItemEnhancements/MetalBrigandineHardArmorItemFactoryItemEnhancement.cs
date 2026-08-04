namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalBrigandineHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(ReflectAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "290"),
        (nameof(ValueAttribute), "1100"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-3"),
        (nameof(BaseArmorClassAttribute), "19"),
    };
}
