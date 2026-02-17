namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfIrritationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(ValuelessAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
    };
    public override string? FriendlyName => "of Irritation";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ToDamageAttribute), "1d15"),
        (nameof(MeleeToHitAttribute), "1d15"),
        (nameof(ValueAttribute), "-10000"),
    };
}
