namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResChaosItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResChaosAttribute), true) };
    }
}