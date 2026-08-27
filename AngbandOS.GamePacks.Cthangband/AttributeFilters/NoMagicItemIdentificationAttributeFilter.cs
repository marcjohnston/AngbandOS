namespace AngbandOS.GamePacks.Cthangband
{
    public class NoMagicItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(NoMagicAttribute), true) };
    }
}