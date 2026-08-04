namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResAcidItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResAcidAttribute), true) };
    }
}