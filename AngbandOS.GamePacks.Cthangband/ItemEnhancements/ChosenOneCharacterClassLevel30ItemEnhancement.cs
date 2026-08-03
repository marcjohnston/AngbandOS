namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel30ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResLightAttribute), "true"),
    };
}