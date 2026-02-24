namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayOrcItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayOrcAttribute), true) };
    }
}