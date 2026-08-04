namespace AngbandOS.GamePacks.Cthangband
{
    public class SustWisItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SustWisAttribute), true) };
    }
}