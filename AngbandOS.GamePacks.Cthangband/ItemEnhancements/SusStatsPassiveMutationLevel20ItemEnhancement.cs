namespace AngbandOS.GamePacks.Cthangband;

public class SusStatsPassiveMutationLevel20ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustDexAttribute), "true"),
    };
}
