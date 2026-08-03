namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel12ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SlowDigestAttribute), "true"),
    };
}