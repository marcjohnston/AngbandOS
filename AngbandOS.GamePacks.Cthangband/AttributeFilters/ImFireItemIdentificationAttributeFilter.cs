namespace AngbandOS.GamePacks.Cthangband
{
    public class ImFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ImFireAttribute), true) };
    }
}