namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel38ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
    };
}