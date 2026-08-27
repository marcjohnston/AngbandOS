namespace AngbandOS.GamePacks.Cthangband;
    public class MoronicPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusIntelligenceAttribute), "4"),
        (nameof(BonusWisdomAttribute), "4"),
    };
}