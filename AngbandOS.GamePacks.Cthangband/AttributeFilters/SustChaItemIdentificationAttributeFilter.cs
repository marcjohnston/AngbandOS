namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustChaItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SustChaAttribute), true) };
    }
}