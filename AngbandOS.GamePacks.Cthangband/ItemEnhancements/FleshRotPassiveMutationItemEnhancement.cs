namespace AngbandOS.GamePacks.Cthangband;
    public class FleshRotPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SuppressRegenAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(CharismaAttribute), "-1"),
    };
}