namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayUndeadItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayUndeadAttribute), true) };
    }
}