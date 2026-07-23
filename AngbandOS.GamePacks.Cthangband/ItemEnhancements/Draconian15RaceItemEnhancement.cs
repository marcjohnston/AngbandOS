namespace AngbandOS.GamePacks.Cthangband;

public class Draconian15RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResAcidAttribute), "true"),
    };
}
