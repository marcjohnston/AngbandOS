namespace AngbandOS.GamePacks.Cthangband;
    public class FleshRotPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SuppressRegenAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusCharismaAttribute), "-1"),
    };
}