namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChaoticItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ChaoticAttribute), true) };
    }
}