namespace AngbandOS.GamePacks.Cthangband;
    public class InfravisPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(InfravisionAttribute), "3"),
    };
}