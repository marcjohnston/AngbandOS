namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResChaosItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResChaosAttribute), true) };
    }
}