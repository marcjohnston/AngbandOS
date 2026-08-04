namespace AngbandOS.GamePacks.Cthangband
{
    public class BrandAcidItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandAcidAttribute), true) };
    }
}