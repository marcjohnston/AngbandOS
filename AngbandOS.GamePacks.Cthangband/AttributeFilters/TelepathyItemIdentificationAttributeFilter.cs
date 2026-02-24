namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TelepathyItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(TelepathyAttribute), true) };
    }
}