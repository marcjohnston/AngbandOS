namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResElecAttribute), true) };
    }
}