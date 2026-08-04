namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ShFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ShFireAttribute), true) };
    }
}