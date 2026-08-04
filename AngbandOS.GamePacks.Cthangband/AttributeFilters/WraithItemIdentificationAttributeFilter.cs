namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WraithItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(WraithAttribute), true) };
    }
}