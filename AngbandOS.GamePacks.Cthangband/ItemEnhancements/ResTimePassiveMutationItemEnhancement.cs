namespace AngbandOS.GamePacks.Cthangband;
    public class ResTimePassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResTimeAttribute), "true"),
    };
}