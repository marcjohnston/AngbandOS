namespace AngbandOS.GamePacks.Cthangband
{
    public class ResPoisItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResPoisAttribute), true) };
    }
}