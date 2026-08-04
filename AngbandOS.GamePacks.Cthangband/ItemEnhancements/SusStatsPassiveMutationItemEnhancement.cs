namespace AngbandOS.GamePacks.Cthangband;
    public class SusStatsPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustChaAttribute), "true"),
        (nameof(SustConAttribute), "true"),
        (nameof(SustDexAttribute), "true"),
        (nameof(SustIntAttribute), "true"),
        (nameof(SustStrAttribute), "true"),
        (nameof(SustWisAttribute), "true"),
    };
}