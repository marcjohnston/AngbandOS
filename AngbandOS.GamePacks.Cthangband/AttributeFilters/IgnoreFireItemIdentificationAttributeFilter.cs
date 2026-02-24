namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreFireAttribute), true) };
    }
}