namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResNetherItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResNetherAttribute), true) };
    }
}