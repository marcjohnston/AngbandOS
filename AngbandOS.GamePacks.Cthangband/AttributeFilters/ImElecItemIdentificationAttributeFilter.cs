namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImElecAttribute), true) };
    }
}