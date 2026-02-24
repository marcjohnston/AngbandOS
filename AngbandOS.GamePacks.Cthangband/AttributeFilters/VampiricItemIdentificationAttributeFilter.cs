namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class VampiricItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(VampiricAttribute), true) };
    }
}