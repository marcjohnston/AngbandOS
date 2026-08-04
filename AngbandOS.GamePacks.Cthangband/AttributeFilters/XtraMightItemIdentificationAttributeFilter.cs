namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class XtraMightItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(XtraMightAttribute), true) };
    }
}