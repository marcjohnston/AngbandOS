namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResColdItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResColdAttribute), true) };
    }
}