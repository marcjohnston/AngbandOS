namespace AngbandOS.GamePacks.Cthangband;
    public class InfravisPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(InfravisionAttribute), "3"),
    };
}