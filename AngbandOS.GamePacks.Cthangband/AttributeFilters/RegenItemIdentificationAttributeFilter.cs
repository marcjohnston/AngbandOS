namespace AngbandOS.GamePacks.Cthangband
{
    public class RegenItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string AttributeKey, bool DesiredValue)[] { (nameof(RegenAttribute), true) };
    }
}