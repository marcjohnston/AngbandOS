namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResDarkItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResDarkAttribute), true) };
    }
}