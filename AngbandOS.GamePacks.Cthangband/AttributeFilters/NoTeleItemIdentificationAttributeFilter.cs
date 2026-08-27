namespace AngbandOS.GamePacks.Cthangband
{
    public class NoTeleItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(NoTeleAttribute), true) };
    }
}