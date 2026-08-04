namespace AngbandOS.GamePacks.Cthangband
{
    public class WraithItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(WraithAttribute), true) };
    }
}