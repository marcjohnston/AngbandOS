namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlowDigestItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlowDigestAttribute), true) };
    }
}