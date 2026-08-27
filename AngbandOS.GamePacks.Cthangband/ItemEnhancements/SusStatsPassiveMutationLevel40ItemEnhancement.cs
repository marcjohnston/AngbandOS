namespace AngbandOS.GamePacks.Cthangband;

public class SusStatsPassiveMutationLevel40ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustIntAttribute), "true"),
    };
}
