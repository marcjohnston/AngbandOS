namespace AngbandOS.GamePacks.Cthangband;
    public class ElecTouchMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ShElecAttribute), "true"),
    };
}