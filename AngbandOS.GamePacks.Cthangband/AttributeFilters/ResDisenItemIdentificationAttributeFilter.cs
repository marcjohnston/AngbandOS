namespace AngbandOS.GamePacks.Cthangband
{
    public class ResDisenItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResDisenAttribute), true) };
    }
}