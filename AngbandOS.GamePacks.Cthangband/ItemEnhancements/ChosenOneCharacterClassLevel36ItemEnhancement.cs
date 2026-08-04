namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel36ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResDisenAttribute), "true"),
    };
}