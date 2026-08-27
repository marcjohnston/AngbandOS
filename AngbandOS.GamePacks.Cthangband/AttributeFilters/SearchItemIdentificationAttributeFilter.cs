namespace AngbandOS.GamePacks.Cthangband
{
    public class SearchItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SearchAttribute), 1, null) };
    }
}