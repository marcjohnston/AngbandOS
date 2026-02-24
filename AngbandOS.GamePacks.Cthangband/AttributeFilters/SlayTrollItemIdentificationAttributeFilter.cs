namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayTrollItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayTrollAttribute), true) };
    }
}