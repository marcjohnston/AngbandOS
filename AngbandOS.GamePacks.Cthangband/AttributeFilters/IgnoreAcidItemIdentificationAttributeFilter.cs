namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreAcidItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreAcidAttribute), true) };
    }
}