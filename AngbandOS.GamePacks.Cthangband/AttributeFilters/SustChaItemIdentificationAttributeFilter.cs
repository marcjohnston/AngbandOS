namespace AngbandOS.GamePacks.Cthangband
{
    public class SustChaItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SustChaAttribute), true) };
    }
}