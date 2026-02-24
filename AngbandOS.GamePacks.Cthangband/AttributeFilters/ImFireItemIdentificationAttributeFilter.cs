namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImFireAttribute), true) };
    }
}