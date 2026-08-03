namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel22ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HoldLifeAttribute), "true"),
    };
}