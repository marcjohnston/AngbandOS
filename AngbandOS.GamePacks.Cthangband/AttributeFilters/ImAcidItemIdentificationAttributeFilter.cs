namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImAcidItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImAcidAttribute), true) };
    }
}