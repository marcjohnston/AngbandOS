namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShieldOfResistLightningItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "400"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Resist Lightning";
}
