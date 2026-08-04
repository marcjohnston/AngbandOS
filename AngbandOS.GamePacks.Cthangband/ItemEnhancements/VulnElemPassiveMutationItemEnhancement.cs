namespace AngbandOS.GamePacks.Cthangband;
    public class VulnElemPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ElementalVulnerabilityAttribute), "true"),
    };
}