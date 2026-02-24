namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreColdItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreColdAttribute), true) };
    }
}