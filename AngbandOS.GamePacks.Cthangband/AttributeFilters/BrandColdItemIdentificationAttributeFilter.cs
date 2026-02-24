namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandColdItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandColdAttribute), true) };
    }
}