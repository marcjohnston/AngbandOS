namespace AngbandOS.GamePacks.Cthangband;

public class Draconian20RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResElecAttribute), "true"),
    };
}
