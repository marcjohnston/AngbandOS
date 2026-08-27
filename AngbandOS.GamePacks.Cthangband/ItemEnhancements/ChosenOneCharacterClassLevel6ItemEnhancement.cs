namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel6ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResBlindAttribute), "true"),
    };
}