namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImColdItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ImColdAttribute), true) };
    }
}