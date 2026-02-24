namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayAnimalItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayAnimalAttribute), true) };
    }
}