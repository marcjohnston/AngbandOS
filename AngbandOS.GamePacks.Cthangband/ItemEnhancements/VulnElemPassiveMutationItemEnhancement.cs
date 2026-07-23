namespace AngbandOS.GamePacks.Cthangband;
    public class VulnElemPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ElementalVulnerabilityAttribute), "true"),
    };
}