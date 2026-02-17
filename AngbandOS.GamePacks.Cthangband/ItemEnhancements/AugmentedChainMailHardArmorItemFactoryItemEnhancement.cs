namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentedChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(ReflectAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "270"),
        (nameof(ValueAttribute), "900"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(BaseArmorClassAttribute), "16"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
}
