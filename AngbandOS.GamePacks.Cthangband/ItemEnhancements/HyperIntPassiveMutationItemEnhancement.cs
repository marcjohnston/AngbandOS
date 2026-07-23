namespace AngbandOS.GamePacks.Cthangband;
    public class HyperIntPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(IntelligenceAttribute), "4"),
        (nameof(WisdomAttribute), "4"),
    };
}