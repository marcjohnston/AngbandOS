namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayTrollItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayTrollAttribute), true) };
    }
}