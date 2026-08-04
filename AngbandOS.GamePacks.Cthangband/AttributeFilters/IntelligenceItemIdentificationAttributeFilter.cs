namespace AngbandOS.GamePacks.Cthangband
{
    public class IntelligenceItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(IntelligenceAttribute), 1, null) };
    }
}