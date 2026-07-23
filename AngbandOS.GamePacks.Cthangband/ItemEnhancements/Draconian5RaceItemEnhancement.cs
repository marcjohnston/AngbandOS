namespace AngbandOS.GamePacks.Cthangband;

public class Draconian5RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResFireAttribute), "true"),
    };
}
