namespace AngbandOS.GamePacks.Cthangband
{
    public class SlowDigestItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlowDigestAttribute), true) };
    }
}