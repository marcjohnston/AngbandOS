namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreAcidItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreAcidAttribute), true) };
    }
}