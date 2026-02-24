namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResPoisItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResPoisAttribute), true) };
    }
}