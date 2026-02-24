namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResBlindItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResBlindAttribute), true) };
    }
}