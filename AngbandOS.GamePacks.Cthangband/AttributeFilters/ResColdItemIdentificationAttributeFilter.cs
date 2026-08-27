namespace AngbandOS.GamePacks.Cthangband
{
    public class ResColdItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResColdAttribute), true) };
    }
}