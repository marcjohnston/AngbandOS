namespace AngbandOS.GamePacks.Cthangband;
public class MindFlayer15RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SeeInvisAttribute), "true"),
    };
}