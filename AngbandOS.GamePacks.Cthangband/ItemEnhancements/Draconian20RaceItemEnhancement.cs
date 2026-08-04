namespace AngbandOS.GamePacks.Cthangband;

public class Draconian20RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResElecAttribute), "true"),
    };
}
