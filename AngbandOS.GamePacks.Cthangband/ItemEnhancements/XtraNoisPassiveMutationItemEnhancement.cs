namespace AngbandOS.GamePacks.Cthangband;
    public class XtraNoisPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StealthAttribute), "-3"),
    };
}