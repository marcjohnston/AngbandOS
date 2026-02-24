namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseBrandColdItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandColdAttribute), false),
    };
}