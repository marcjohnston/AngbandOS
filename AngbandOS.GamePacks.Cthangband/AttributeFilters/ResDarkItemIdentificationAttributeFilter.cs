namespace AngbandOS.GamePacks.Cthangband
{
    public class ResDarkItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResDarkAttribute), true) };
    }
}