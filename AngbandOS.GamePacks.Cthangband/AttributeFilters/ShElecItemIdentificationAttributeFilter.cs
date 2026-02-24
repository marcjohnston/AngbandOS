namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ShElecItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ShElecAttribute), true) };
    }
}