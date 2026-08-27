namespace AngbandOS.GamePacks.Cthangband;

public class SusStatsPassiveMutationLevel10ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustStrAttribute), "true"),
    };
}
