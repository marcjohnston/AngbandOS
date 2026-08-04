namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandPoisItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandPoisAttribute), true) };
    }
}