namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DrainExpItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(DrainExpAttribute), true) };
    }
}