namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel8ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FeatherAttribute), "true"),
    };
}