namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayEvilItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayEvilAttribute), true) };
    }
}