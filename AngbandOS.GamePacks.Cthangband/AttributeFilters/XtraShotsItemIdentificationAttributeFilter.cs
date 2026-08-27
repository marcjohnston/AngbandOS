namespace AngbandOS.GamePacks.Cthangband
{
    public class XtraShotsItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(XtraShotsAttribute), true) };
    }
}