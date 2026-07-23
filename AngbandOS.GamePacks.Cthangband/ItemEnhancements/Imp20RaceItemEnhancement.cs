namespace AngbandOS.GamePacks.Cthangband;
    public class Imp20RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ImFireAttribute), "true"),
    };
}