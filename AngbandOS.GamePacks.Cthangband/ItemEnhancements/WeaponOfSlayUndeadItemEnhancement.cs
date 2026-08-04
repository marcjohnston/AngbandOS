namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayUndeadItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SlayUndeadAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
        (nameof(TreasureRatingAttribute), "18"),
    };
    public override string? FriendlyName => "of Slay Undead";
}
