namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResSoundItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResSoundAttribute), true) };
    }
}