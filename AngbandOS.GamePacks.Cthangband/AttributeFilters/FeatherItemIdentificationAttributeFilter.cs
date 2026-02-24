namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FeatherItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(FeatherAttribute), true) };
    }
}