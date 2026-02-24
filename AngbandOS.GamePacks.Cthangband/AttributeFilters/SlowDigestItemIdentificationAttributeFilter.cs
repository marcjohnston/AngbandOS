namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlowDigestItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlowDigestAttribute), true) };
    }
}