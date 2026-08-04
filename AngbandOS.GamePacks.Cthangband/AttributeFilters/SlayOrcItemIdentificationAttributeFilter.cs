namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayOrcItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayOrcAttribute), true) };
    }
}