namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class NoMagicItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(NoMagicAttribute), true) };
    }
}