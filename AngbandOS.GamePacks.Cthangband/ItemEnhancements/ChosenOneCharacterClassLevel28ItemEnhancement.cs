namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel28ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResDarkAttribute), "true"),
    };
}