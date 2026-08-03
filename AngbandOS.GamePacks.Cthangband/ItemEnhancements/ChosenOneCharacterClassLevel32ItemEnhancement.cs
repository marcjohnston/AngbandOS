namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel32ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustChaAttribute), "true"),
    };
}