namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfHurtAnimalItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SlayAnimalAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "25"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Hurt Animal";
}
