namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IntelligenceItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(IntelligenceAttribute), 1, null) };
    }
}