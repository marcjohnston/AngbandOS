namespace AngbandOS.GamePacks.Cthangband
{
    public class ResSoundItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResSoundAttribute), true) };
    }
}