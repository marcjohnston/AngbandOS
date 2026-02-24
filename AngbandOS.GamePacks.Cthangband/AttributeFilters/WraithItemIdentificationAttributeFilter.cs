namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WraithItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(WraithAttribute), true) };
    }
}