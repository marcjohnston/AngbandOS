namespace AngbandOS.GamePacks.Cthangband
{
    public class SustStrItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SustStrAttribute), true) };
    }
}