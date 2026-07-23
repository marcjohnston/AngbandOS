namespace AngbandOS.GamePacks.Cthangband;
    public class Yeek20RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ImAcidAttribute), "true"),
    };
}