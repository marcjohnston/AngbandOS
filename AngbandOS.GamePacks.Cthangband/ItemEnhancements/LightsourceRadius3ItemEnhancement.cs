namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightsourceRadius3ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "3"),
    };
}
