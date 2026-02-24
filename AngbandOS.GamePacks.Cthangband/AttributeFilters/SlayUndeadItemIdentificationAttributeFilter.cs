namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayUndeadItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayUndeadAttribute), true) };
    }
}