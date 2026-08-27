namespace AngbandOS.GamePacks.Cthangband;
    public class ElecTouchMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ShElecAttribute), "true"),
    };
}