namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayOrcItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayOrcAttribute), true) };
    }
}