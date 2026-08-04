namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel48ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResShardsAttribute), "true"),
    };
}