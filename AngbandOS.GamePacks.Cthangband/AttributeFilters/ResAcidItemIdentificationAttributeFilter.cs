namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResAcidItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResAcidAttribute), true) };
    }
}