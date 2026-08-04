namespace AngbandOS.GamePacks.Cthangband;
    public class EspPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(TelepathyAttribute), "true"),
    };
}