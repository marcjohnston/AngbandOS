namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseBrandAcidItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandAcidAttribute), false),
    };
}