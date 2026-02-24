namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustDexItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SustDexAttribute), true) };
    }
}