namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustIntItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SustIntAttribute), true) };
    }
}