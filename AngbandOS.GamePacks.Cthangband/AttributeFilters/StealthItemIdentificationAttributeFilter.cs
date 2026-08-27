namespace AngbandOS.GamePacks.Cthangband
{
    public class StealthItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(StealthAttribute), 1, null) };
    }
}