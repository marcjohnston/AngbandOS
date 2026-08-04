namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ImFireAttribute), true) };
    }
}