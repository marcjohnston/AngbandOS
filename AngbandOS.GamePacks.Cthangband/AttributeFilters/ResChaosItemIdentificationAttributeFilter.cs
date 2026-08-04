namespace AngbandOS.GamePacks.Cthangband
{
    public class ResChaosItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResChaosAttribute), true) };
    }
}