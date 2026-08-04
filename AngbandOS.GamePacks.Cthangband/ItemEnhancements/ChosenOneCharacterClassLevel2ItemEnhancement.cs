namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel2ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResConfAttribute), "true"),
    };
}