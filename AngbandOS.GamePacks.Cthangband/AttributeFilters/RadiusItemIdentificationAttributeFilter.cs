namespace AngbandOS.GamePacks.Cthangband
{
    public class RadiusItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(GlowRadiusAttribute), 1, null), (nameof(BurnRateAttribute), 1, null) };
    }
}