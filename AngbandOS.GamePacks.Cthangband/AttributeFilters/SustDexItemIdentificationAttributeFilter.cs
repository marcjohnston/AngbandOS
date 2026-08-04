namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustDexItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SustDexAttribute), true) };
    }
}