namespace AngbandOS.GamePacks.Cthangband
{
    public class VampiricItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(VampiricAttribute), true) };
    }
}