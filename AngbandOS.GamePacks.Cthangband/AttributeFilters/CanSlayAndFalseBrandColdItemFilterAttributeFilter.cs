namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseBrandColdItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandColdAttribute), false),
    };
}