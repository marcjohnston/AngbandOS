namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandElecAttribute), true) };
    }
}