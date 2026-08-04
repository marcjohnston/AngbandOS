namespace AngbandOS.GamePacks.Cthangband
{
    public class IgnoreElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreElecAttribute), true) };
    }
}