namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel20ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustStrAttribute), "true"),
    };
}