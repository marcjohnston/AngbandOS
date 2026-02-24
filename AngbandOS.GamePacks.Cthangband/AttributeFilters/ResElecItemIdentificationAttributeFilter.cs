namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResElecAttribute), true) };
    }
}