namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel26ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(TelepathyAttribute), "true"),
    };
}