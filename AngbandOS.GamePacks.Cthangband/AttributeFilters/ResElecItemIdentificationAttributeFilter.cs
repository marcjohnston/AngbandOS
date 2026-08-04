namespace AngbandOS.GamePacks.Cthangband
{
    public class ResElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResElecAttribute), true) };
    }
}