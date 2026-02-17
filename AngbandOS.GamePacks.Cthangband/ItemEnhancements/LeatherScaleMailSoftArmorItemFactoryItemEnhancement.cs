namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeatherScaleMailSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(HatesFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "140"),
        (nameof(ValueAttribute), "450"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(MeleeToHitAttribute), "-1"),
        (nameof(BaseArmorClassAttribute), "11"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
