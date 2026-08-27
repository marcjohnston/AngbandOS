namespace AngbandOS.GamePacks.Cthangband
{
    public class ShElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ShElecAttribute), true) };
    }
}