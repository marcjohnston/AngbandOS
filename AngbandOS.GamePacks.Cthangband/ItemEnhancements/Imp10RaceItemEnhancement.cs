namespace AngbandOS.GamePacks.Cthangband;
    public class Imp10RaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SeeInvisAttribute), "true"),
    };
}