namespace AngbandOS.GamePacks.Cthangband;
    public class Skeleton10RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResColdAttribute), "true"),
    };
}