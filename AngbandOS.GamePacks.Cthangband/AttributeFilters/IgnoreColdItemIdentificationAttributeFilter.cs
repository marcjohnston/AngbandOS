namespace AngbandOS.GamePacks.Cthangband
{
    public class IgnoreColdItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreColdAttribute), true) };
    }
}