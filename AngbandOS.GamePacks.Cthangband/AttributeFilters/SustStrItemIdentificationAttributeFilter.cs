namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustStrItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SustStrAttribute), true) };
    }
}