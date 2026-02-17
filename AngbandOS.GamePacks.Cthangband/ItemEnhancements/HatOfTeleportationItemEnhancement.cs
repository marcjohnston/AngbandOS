namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfTeleportationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
        (nameof(TeleportAttribute), "true"),
    };
    public override string? FriendlyName => "of Teleportation";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "250"),
    };
}
