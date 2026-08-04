namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreFireAttribute), true) };
    }
}