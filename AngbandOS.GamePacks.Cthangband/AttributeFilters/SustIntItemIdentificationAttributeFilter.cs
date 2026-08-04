namespace AngbandOS.GamePacks.Cthangband
{
    public class SustIntItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SustIntAttribute), true) };
    }
}