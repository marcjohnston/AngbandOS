namespace AngbandOS.GamePacks.Cthangband;

public class Draconian5RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResFireAttribute), "true"),
    };
}
