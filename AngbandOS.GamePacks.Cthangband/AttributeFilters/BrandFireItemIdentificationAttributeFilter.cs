namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandFireAttribute), true) };
    }
}