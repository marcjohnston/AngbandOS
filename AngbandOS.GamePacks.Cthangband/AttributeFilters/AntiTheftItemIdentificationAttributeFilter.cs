namespace AngbandOS.GamePacks.Cthangband
{
    public class AntiTheftItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(AntiTheftAttribute), true) };
    }
}