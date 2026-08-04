namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElfSkeletonSkeletonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(EasyKnowAttribute), "true"),
        (nameof(ValuelessAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "40"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "2"),
    };
}
