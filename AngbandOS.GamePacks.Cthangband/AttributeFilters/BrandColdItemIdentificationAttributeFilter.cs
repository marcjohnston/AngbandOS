namespace AngbandOS.GamePacks.Cthangband
{
    public class BrandColdItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandColdAttribute), true) };
    }
}