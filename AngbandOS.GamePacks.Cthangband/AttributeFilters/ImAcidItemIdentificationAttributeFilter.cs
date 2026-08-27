namespace AngbandOS.GamePacks.Cthangband
{
    public class ImAcidItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ImAcidAttribute), true) };
    }
}