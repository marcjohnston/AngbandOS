namespace AngbandOS.GamePacks.Cthangband;
    public class MagicResPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResMagicAttribute), "true"),
    };
}