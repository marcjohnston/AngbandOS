namespace AngbandOS.GamePacks.Cthangband;
public class CanSlayAndFalseBrandAcidItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandAcidAttribute), false),
    };
}