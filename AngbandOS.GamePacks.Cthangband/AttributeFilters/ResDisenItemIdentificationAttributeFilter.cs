namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResDisenItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResDisenAttribute), true) };
    }
}