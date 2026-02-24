namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResNetherItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResNetherAttribute), true) };
    }
}