namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AntiTheftItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(AntiTheftAttribute), true) };
    }
}