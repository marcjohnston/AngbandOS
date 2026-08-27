namespace AngbandOS.GamePacks.Cthangband
{
    public class BrandElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandElecAttribute), true) };
    }
}