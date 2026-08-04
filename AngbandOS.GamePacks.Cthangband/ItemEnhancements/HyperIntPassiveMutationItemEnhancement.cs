namespace AngbandOS.GamePacks.Cthangband;
    public class HyperIntPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(IntelligenceAttribute), "4"),
        (nameof(WisdomAttribute), "4"),
    };
}