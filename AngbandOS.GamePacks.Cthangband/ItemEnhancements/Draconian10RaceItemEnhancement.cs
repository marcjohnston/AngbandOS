namespace AngbandOS.GamePacks.Cthangband;

public class Draconian10RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResColdAttribute), "true"),
    };
}
