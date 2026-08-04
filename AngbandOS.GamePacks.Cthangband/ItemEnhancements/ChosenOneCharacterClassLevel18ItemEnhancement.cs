namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel18ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustDexAttribute), "true"),
    };
}