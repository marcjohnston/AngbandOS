namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FeatherItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(FeatherAttribute), true) };
    }
}