namespace AngbandOS.GamePacks.Cthangband;
    public class HalfTroll15RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
}