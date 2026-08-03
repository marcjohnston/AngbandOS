namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel14ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustConAttribute), "true"),
    };
}