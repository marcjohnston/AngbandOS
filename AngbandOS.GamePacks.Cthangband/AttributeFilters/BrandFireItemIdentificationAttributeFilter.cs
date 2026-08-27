namespace AngbandOS.GamePacks.Cthangband
{
    public class BrandFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandFireAttribute), true) };
    }
}