namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel44ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustWisAttribute), "true"),
    };
}