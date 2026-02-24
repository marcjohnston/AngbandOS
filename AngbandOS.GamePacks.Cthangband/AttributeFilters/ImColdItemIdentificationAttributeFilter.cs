namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImColdItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImColdAttribute), true) };
    }
}