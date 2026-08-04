namespace AngbandOS.GamePacks.Cthangband
{
    public class ResBlindItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResBlindAttribute), true) };
    }
}