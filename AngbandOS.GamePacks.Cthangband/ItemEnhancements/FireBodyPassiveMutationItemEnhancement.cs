namespace AngbandOS.GamePacks.Cthangband;
    public class FireBodyPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ShFireAttribute), "true"),
    };
}