namespace AngbandOS.GamePacks.Cthangband;

public class LightsourceRadius3ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(GlowRadiusAttribute), "3"),
    };
}
