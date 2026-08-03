namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel42ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResChaosAttribute), "true"),
    };
}