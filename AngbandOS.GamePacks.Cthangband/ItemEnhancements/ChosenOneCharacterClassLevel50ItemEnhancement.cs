namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel50ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResNetherAttribute), "true"),
    };
}