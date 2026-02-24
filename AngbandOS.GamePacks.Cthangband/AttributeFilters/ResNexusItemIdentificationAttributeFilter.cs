namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResNexusItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResNexusAttribute), true) };
    }
}