namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustConItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SustConAttribute), true) };
    }
}